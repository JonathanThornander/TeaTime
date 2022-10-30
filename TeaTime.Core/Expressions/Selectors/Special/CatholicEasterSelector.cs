using System;

namespace TeaTime.Core.Expressions.Selectors.Special
{

    public class CatholicEasterSelector : SelectorExpression
    {
        public CatholicEasterSelector(bool negate) : base(negate)
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
            var easterThisYear = GetCatholicEaster(reference.Year);

            if (reference.Date == easterThisYear.Date)
            {
                return new DateTime(reference.Year, reference.Month, reference.Day).AddDays(1);
            }

            return reference;
        }

        private DateTime Create(DateTime reference)
        {
            return GetCatholicEaster(reference.Year);
        }

        internal override string GetSignature()
        {
            var prefix = _negate ? "!" : "";
            return $"{prefix}Easter:Orthodox";
        }

        internal override ValidationResult Validate() => new ValidationResult(true);

        private static DateTime GetCatholicEaster(int year)
        {
            int month = 3;
            int G = year % 19 + 1;
            int C = year / 100 + 1;
            int X = 3 * C / 4 - 12;
            int Y = (8 * C + 5) / 25 - 5;
            int Z = 5 * year / 4 - X - 10;
            int E = (11 * G + 20 + Y - X) % 30;
            if (E == 24) { E++; }
            if (E == 25 && G > 11) { E++; }
            int N = 44 - E;
            if (N < 21) { N = N + 30; }
            int P = N + 7 - (Z + N) % 7;
            if (P > 31)
            {
                P -= 31;
                month = 4;
            }
            return new DateTime(year, month, P);
        }
    }
}
