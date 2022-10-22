using System;

namespace Tea.Core.Expressions.Selectors.Special
{
    public class OrthodoxEasterSelector : SelectorExpression
    {
        public OrthodoxEasterSelector(bool negate) : base(negate)
        {
        }

        protected override DateTime? GetNext(DateTime reference)
        {
            var created = Create(reference);

            if (created.Date == reference.Date)
            {
                return reference;
            }
            if (created < reference)
            {
                return Create(reference.AddYears(1));
            }

            return created;
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            var easterThisYear = GetOrthodoxEaster(reference.Year);

            if (reference.Date == easterThisYear.Date)
            {
                return new DateTime(reference.Year, reference.Month, reference.Day).AddDays(1);
            }

            return reference;
        }

        private DateTime Create(DateTime reference)
        {
            return GetOrthodoxEaster(reference.Year);
        }

        internal override string GetSignature()
        {
            var prefix = _negate ? "!" : "";
            return $"{prefix}Easter:Catholic";
        }

        internal override ValidationResult Validate() => new ValidationResult(true);

        private static DateTime GetOrthodoxEaster(int year)
        {
            int a = year % 19;
            int b = year % 7;
            int c = year % 4;

            int d = (19 * a + 16) % 30;
            int e = (2 * c + 4 * b + 6 * d) % 7;
            int f = (19 * a + 16) % 30;
            int key = f + e + 3;

            int month = (key > 30) ? 5 : 4;
            int day = (key > 30) ? key - 30 : key;

            return new DateTime(year, month, day);
        }
    }
}
