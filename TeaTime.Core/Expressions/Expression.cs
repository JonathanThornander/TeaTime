using System;
using System.Collections.Generic;
using TeaTime.Core.Exceptions;

namespace TeaTime.Core.Expressions
{
    public abstract class Expression
    {
        private bool _validated = false;

        public string Signature { get => GetSignature(); }

        public virtual DateTime? NextOccurance(DateTime reference)
        {
            EnsureValidated();
            return GetNext(reference);
        }

        public IEnumerable<DateTime> GetBetween(DateTime from, DateTime to)
        {
            EnsureValidated();
            var reference = new DateTime(from.Year, from.Month, from.Day, from.Hour, from.Minute, from.Second);

            var nextPotential = GetNext(reference);

            while (nextPotential < to)
            {
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
                nextPotential = GetNext(reference);
            }
        }

        internal virtual void Clean()
        {
            return;
        }

        internal abstract string GetSignature();

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

    internal class ValidationResult
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
