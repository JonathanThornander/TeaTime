using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Core.Expressions.Selectors.Modular
{
    public class MinuteModFunction : SelectorExpression
    {
        private readonly int _modValue;

        public MinuteModFunction(int modValue, bool negate = false) : base(negate)
        {
            _modValue = modValue;
        }

        protected override DateTime? GetNext(DateTime reference)
        {
            var MinutesToNext = reference.Minute % _modValue;

            if (MinutesToNext == 0)
            {
                return reference;
            }

            return Create(reference).AddMinutes(MinutesToNext);
        }

        private static DateTime Create(DateTime reference)
        {
            return new DateTime(reference.Year, reference.Month, reference.Day, reference.Hour, reference.Minute, 0);
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            var MinutesToNext = reference.Minute % _modValue;

            if (MinutesToNext == 0)
            {
                return Create(reference).AddMinutes(1);
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
