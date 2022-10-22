using System;

namespace Tea.Core.Expressions.Selectors
{
    public class YearSelector : SelectorExpression
    {
        private readonly int _year;
        public YearSelector(int year, bool negate = false) : base(negate)
        {
            _year = year;
        }

        internal override string GetSignature() => $"Y:{_year}";

        protected override DateTime? GetNext(DateTime reference)
        {
            if (reference.Year == _year)
            {
                return reference;
            }
            else if (reference.Year < _year)
            {
                return Create(reference);
            }
            else
            {
                return null;
            };
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            if (reference.Year == _year)
            {
                return Create(reference).AddYears(1);
            }
            else
            {
                return reference;
            }
        }

        internal override ValidationResult Validate()
        {
            if (_year > DateTime.MaxValue.Year)
            {
                return new ValidationResult(false, "Year value is to high");
            }
            else if (_year < DateTime.MinValue.Year)
            {
                return new ValidationResult(false, "Year value is to low");
            }

            return new ValidationResult(true);
        }

        internal override DateTime Create(DateTime reference)
        {
            return new DateTime(_year, 1, 1);
        }


    }
}
