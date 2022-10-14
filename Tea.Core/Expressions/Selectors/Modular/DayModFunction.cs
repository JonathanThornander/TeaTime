using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Core.Expressions.Selectors.Modular
{
    public class DayModFunction : SelectorExpression
    {
        private readonly int _modValue;

        public DayModFunction(int modValue, bool negate = false) : base(negate)
        {
            _modValue = modValue;
        }

        protected override DateTime? GetNext(DateTime reference)
        {
            var DaysToNext = _modValue - (reference.Day % _modValue);

            if (DaysToNext == 0)
            {
                return reference;
            }

            return Create(reference).AddDays(DaysToNext);
        }

        private static DateTime Create(DateTime reference)
        {
            return new DateTime(reference.Year, reference.Month, reference.Day, 0, 0, 0);
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            int daysToNext = DaysUntilNext(reference);

            if (daysToNext == 0)
            {
                return Create(reference).AddDays(1);
            }

            return reference;
        }

        private int DaysUntilNext(DateTime reference)
        {
            var modResult = reference.Day % _modValue;

            if (modResult == 0)
            {
                return modResult;
            }
            return _modValue - modResult;
        }

        internal override ValidationResult Validate()
        {
            if (_modValue == 0)
            {
                return new ValidationResult(false, "Mod value cannot be zero");
            }

            return new ValidationResult(true);
        }
    }
}
