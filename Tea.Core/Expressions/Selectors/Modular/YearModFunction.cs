using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Core.Expressions.Selectors.Modular
{
    public class YearModFunction : SelectorExpression
    {
        private readonly int _modValue;

        public YearModFunction(int modValue, bool negate = false) : base(negate)
        {
            _modValue = modValue;
        }

        internal override string GetSignature() => $"Y%:{_modValue}";

        protected override DateTime? GetNext(DateTime reference)
        {
            var yearsToNext = YearsToNext(reference);

            if (yearsToNext == 0)
            {
                return reference;
            }

            var created = Create(reference);
            var next = created.AddYears(yearsToNext);
            return next;
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            var yearsToNext = YearsToNext(reference);

            if (yearsToNext == 0)
            {
                return Create(reference).AddYears(1);
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

        private int YearsToNext(DateTime reference)
        {
            var modResult = reference.Year % _modValue;

            if (modResult == 0)
            {
                return modResult;
            }
            return _modValue - modResult;
        }

        private static DateTime Create(DateTime reference)
        {
            return new DateTime(reference.Year, 1, 1);
        }
    }
}
