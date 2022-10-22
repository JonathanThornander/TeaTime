using System;

namespace Tea.Core.Expressions.Selectors
{
    public class SecondOfMinuteSelector : SelectorExpression
    {
        private readonly int _second;

        public SecondOfMinuteSelector(int second, bool negate = false) : base(negate)
        {
            _second = second;
        }

        internal override string GetSignature() => $"SS:{_second}";

        protected override DateTime? GetNext(DateTime reference)
        {
            if (reference.Second == _second)
            {
                return reference;
            }
            else if (reference.Second < _second)
            {
                return Create(reference);
            }
            else
            {
                return Create(reference).AddMinutes(1);
            }
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            if (reference.Second == _second)
            {
                return Create(reference).AddSeconds(1);
            }
            else
            {
                return reference;
            }
        }

        internal override ValidationResult Validate()
        {
            if (_second < 0)
            {
                return new ValidationResult(false, "Second must be equal or grater than 0");
            }
            else if (_second > 59)
            {
                return new ValidationResult(false, "Second must be less or equal to 59");
            }

            return new ValidationResult(true);
        }

        internal override DateTime Create(DateTime reference)
        {
            return new DateTime(reference.Year, reference.Month, reference.Day, reference.Hour, reference.Minute, _second);
        }
    }
}
