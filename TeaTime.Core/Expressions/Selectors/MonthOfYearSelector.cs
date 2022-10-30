using System;

namespace TeaTime.Core.Expressions.Selectors
{
    public class MonthOfYearSelector : SelectorExpression
    {
        private readonly int _month;

        public MonthOfYearSelector(int month, bool negate = false) : base(negate)
        {
            _month = month;
        }

        internal override string GetSignature() => $"M:{_month}";

        protected override DateTime? GetNext(DateTime reference)
        {
            if (reference.Month == _month)
            {
                return reference;
            }
            else if (reference.Month < _month)
            {
                return Create(reference);
            }
            else
            {
                return Create(reference).AddYears(1);
            }
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            if (reference.Month == _month)
            {
                return Create(reference).AddMonths(1);
            }
            else
            {
                return reference;
            }
        }

        internal override ValidationResult Validate()
        {
            if (_month < 1)
            {
                return new ValidationResult(false, "Month must be equal or grater than 1");
            }
            else if (_month > 12)
            {
                return new ValidationResult(false, "Month must be less or equal to 12");
            }

            return new ValidationResult(true);
        }

        private DateTime Create(DateTime reference)
        {
            return new DateTime(reference.Year, _month, 1, 0, 0, 0);
        }
    }
}
