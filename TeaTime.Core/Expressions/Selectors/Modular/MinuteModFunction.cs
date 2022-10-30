using System;

namespace TeaTime.Core.Expressions.Selectors.Modular
{
    public class MinuteModFunction : SelectorExpression
    {
        private readonly int _modValue;

        public MinuteModFunction(int modValue, bool negate = false) : base(negate)
        {
            _modValue = modValue;
        }

        internal override string GetSignature() => $"MM%:{_modValue}";

        protected override DateTime? GetNext(DateTime reference)
        {
            var minutesToNext = MinutesToNext(reference);

            if (minutesToNext == 0)
            {
                return reference;
            }

            return Create(reference).AddMinutes(minutesToNext);
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            var minutesToNext = MinutesToNext(reference);

            if (minutesToNext == 0)
            {
                return Create(reference).AddMinutes(1);
            }

            return reference;
        }

        private DateTime Create(DateTime reference)
        {
            return new DateTime(reference.Year, reference.Month, reference.Day, reference.Hour, reference.Minute, 0);
        }

        internal override ValidationResult Validate()
        {
            if (_modValue == 0)
            {
                return new ValidationResult(false, "Mod value cannot be zero");
            }

            return new ValidationResult(true);
        }

        private int MinutesToNext(DateTime reference)
        {
            var modResult = reference.Minute % _modValue;

            if (modResult == 0)
            {
                return modResult;
            }
            return _modValue - modResult;
        }
    }
}
