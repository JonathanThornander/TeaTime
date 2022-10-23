using System;

namespace Tea.Core.Expressions.Selectors
{
    public class MinuteOfHourSelector : SelectorExpression
    {
        private readonly int _minute;

        public MinuteOfHourSelector(int minute, bool negate = false) : base(negate)
        {
            _minute = minute;
        }

        internal override string GetSignature() => $"MM:{_minute}";

        protected override DateTime? GetNext(DateTime reference)
        {
            if (reference.Minute == _minute)
            {
                return reference;
            }
            else if (reference.Minute < _minute)
            {
                return Create(reference);
            }
            else
            {
                return Create(reference).AddHours(1);
            }
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            if (reference.Minute == _minute)
            {
                return Create(reference).AddMinutes(1);
            }
            else
            {
                return reference;
            }
        }

        internal override ValidationResult Validate()
        {
            if (_minute < 0)
            {
                return new ValidationResult(false, "Minute must be equal or grater than 0");
            }
            else if (_minute > 59)
            {
                return new ValidationResult(false, "Minute must be less or equal to 59");
            }

            return new ValidationResult(true);
        }

        private DateTime Create(DateTime reference)
        {
            return new DateTime(reference.Year, reference.Month, reference.Day, reference.Hour, _minute, 0);
        }
    }
}
