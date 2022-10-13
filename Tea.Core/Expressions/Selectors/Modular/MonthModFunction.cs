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

        protected override DateTime? GetNext(DateTime reference)
        {
            var MonthsToNext = reference.Month % _modValue;

            if (MonthsToNext == 0)
            {
                return reference;
            }

            return Create(reference).AddMonths(MonthsToNext);
        }

        private static DateTime Create(DateTime reference)
        {
            return new DateTime(reference.Year, reference.Month, 1, 0, 0, 0);
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            var MonthsToNext = reference.Month % _modValue;

            if (MonthsToNext == 0)
            {
                return Create(reference).AddMonths(1);
            }

            return reference;
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
