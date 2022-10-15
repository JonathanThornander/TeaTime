using System;

namespace Tea.Core.Expressions.Selectors
{
    public class HourOfDaySelector : SelectorExpression
    {
        private readonly int _hour;

        public HourOfDaySelector(int hour, bool negate = false) : base(negate)
        {
            _hour = hour;
        }

        internal override string GetSignature() => $"HH:{_hour}";

        protected override DateTime? GetNext(DateTime reference)
        {
            if (reference.Hour == _hour)
            {
                return reference;
            }
            else if (reference.Hour < _hour)
            {
                return Create(reference);
            }
            else
            {
                return Create(reference).AddDays(1);
            }
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            if (reference.Hour == _hour)
            {
                return Create(reference).AddHours(1);
            }
            else
            {
                return reference;
            }
        }

        internal override ValidationResult Validate()
        {
            if (_hour < 0)
            {
                return new ValidationResult(false, "Minute must be equal or grater than 0");
            }
            else if (_hour > 23)
            {
                return new ValidationResult(false, "Minute must be less or equal to 23");
            }

            return new ValidationResult(true);
        }

        private DateTime Create(DateTime reference)
        {
            return new DateTime(reference.Year, reference.Month, reference.Day, _hour, 0, 0);
        }

    }
}
