﻿using Tea.Core.Exceptions;

namespace Tea.Core.Expressions
{
    public abstract class Expression
    {
        private bool _validated = false;

        public virtual DateTime? NextOccurance(DateTime reference)
        {
            EnsureValidated();
            return GetNext(reference);
        }

        public IEnumerable<DateTime> GetBetween(DateTime from, DateTime to)
        {
            EnsureValidated();
            var reference = new DateTime(from.Year, from.Month, from.Day, from.Hour, from.Minute, from.Second);

            while (reference <= to)
            {
                var nextPotential = GetNext(reference);

                if (nextPotential == null)
                {
                    break;
                }
                else
                {
                    reference = (DateTime)nextPotential;
                }

                yield return reference;


                reference = reference.AddSeconds(1);
            }
        }

        internal abstract ValidationResult Validate();

        protected abstract DateTime? GetNext(DateTime reference);

        private void EnsureValidated()
        {
            if (_validated == false)
            {
                var result = Validate();

                if (result.Valid == false)
                {
                    throw new ExpressionValidationException(result.Message);
                }

                _validated = true;
            }
        }
    }

    internal record ValidationResult
    {
        public ValidationResult(bool valid)
        {
            Valid = valid;
        }

        public ValidationResult(bool valid, string? message)
        {
            Valid = valid;
            Message = message;
        }

        public bool Valid { get; set; }

        public string? Message { get; set; }
    }
}
