using System;

namespace Tea.Core.Expressions.Selectors
{
    public class DayOfMonthSelector : SelectorExpression
    {
        private readonly int _day;

        public DayOfMonthSelector(int days, bool negate = false) : base(negate)
        {
            _day = days;
        }

        protected override DateTime? GetNext(DateTime reference)
        {
            if (reference.Day == _day)
            {
                return reference;
            }
            else if (reference.Day < _day)
            {
                if (DateTime.DaysInMonth(reference.Year, reference.Month) < _day)
                {
                    return Forward(reference);
                }

                return Create(reference);
            }
            else
            {
                return Forward(reference);
            }
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            if (reference.Day == _day)
            {
                return Create(reference).AddDays(1);
            }
            else
            {
                return reference;
            }
        }

        internal override ValidationResult Validate()
        {
            if (_day < 1)
            {
                return new ValidationResult(false, "Day must be equal or grater than 1");
            }
            else if (_day > 32)
            {
                return new ValidationResult(false, "Day must be less or equal to 32");
            }

            return new ValidationResult(true);
        }

        private DateTime Create(DateTime reference)
        {
            return new DateTime(reference.Year, reference.Month, _day);
        }

        private DateTime Forward(DateTime reference)
        {
            var nextValidMonth = reference.AddMonths(1);

            while (_day > DateTime.DaysInMonth(nextValidMonth.Year, nextValidMonth.Month))
            {
                nextValidMonth = nextValidMonth.AddMonths(1);
            }

            return Create(nextValidMonth);
        }
    }
}
