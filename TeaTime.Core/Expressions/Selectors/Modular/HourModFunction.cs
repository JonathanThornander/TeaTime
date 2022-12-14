using System;

namespace TeaTime.Core.Expressions.Selectors.Modular
{
    public class HourModFunction : SelectorExpression
    {
        private readonly int _modValue;

        public HourModFunction(int modValue, bool negate = false) : base(negate)
        {
            _modValue = modValue;
        }

        internal override string GetSignature() => $"HH%:{_modValue}";

        protected override DateTime? GetNext(DateTime reference)
        {
            var hoursToNext = HoursToNext(reference);

            if (hoursToNext == 0)
            {
                return reference;
            }

            return Create(reference).AddHours(hoursToNext);
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            var hoursToNext = HoursToNext(reference);

            if (hoursToNext == 0)
            {
                return Create(reference).AddHours(1);
            }

            return reference;
        }

        private DateTime Create(DateTime reference)
        {
            return new DateTime(reference.Year, reference.Month, reference.Day, reference.Hour, 0, 0);
        }

        internal override ValidationResult Validate()
        {
            if (_modValue == 0)
            {
                return new ValidationResult(false, "Mod value cannot be zero");
            }

            return new ValidationResult(true);
        }

        private int HoursToNext(DateTime reference)
        {
            var modResult = reference.Hour % _modValue;

            if (modResult == 0)
            {
                return modResult;
            }
            return _modValue - modResult;
        }
    }
}
