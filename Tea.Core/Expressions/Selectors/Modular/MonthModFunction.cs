using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Core.Expressions.Selectors.Modular
{
    public class MonthModFunction : SelectorExpression
    {
        private readonly int _modValue;

        public MonthModFunction(int modValue, bool negate = false) : base(negate)
        {
            _modValue = modValue;
        }

        internal override string GetSignature() => $"M%:{_modValue}";

        protected override DateTime? GetNext(DateTime reference)
        {
            var monthsToNext = MonthsToNext(reference);

            if (monthsToNext == 0)
            {
                return reference;
            }

            return Create(reference).AddMonths(monthsToNext);
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            var monthsToNext = MonthsToNext(reference);

            if (monthsToNext == 0)
            {
                return Create(reference).AddMonths(1);
            }

            return reference;
        }

        private static DateTime Create(DateTime reference)
        {
            return new DateTime(reference.Year, reference.Month, 1, 0, 0, 0);
        }

        internal override ValidationResult Validate()
        {
            if (_modValue == 0)
            {
                return new ValidationResult(false, "Mod value cannot be zero");
            }

            return new ValidationResult(true);
        }

        private int MonthsToNext(DateTime reference)
        {
            var modResult = reference.Month % _modValue;

            if (modResult == 0)
            {
                return modResult;
            }
            return _modValue - modResult;
        }
    }
}
