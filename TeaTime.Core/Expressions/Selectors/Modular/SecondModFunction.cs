using System;

namespace TeaTime.Core.Expressions.Selectors.Modular
{
    public class SecondModFunction : SelectorExpression
    {
        private readonly int _modValue;

        public SecondModFunction(int modValue, bool negate = false) : base(negate)
        {
            _modValue = modValue;
        }

        internal override string GetSignature() => $"SS%:{_modValue}";

        protected override DateTime? GetNext(DateTime reference)
        {
            var secondsToNext = SecondsToNext(reference);

            if (secondsToNext == 0)
            {
                return reference;
            }

            return Create(reference).AddSeconds(secondsToNext);
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            var secondsToNext = SecondsToNext(reference);

            if (secondsToNext == 0)
            {
                return Create(reference).AddSeconds(1);
            }

            return reference;
        }

        private DateTime Create(DateTime reference)
        {
            return new DateTime(reference.Year, reference.Month, reference.Day, reference.Hour, reference.Minute, reference.Second);
        }

        internal override ValidationResult Validate()
        {
            if (_modValue == 0)
            {
                return new ValidationResult(false, "Mod value cannot be zero");
            }

            return new ValidationResult(true);
        }

        private int SecondsToNext(DateTime reference)
        {
            var modResult = reference.Second % _modValue;

            if (modResult == 0)
            {
                return modResult;
            }
            return _modValue - modResult;
        }
    }
}
