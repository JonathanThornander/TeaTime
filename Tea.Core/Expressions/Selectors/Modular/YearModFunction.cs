﻿using System;
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

        protected override DateTime? GetNext(DateTime reference)
        {
            var yearsToNext = reference.Year % _modValue;

            if (yearsToNext == 0)
            {
                return reference;
            }
            
            return Create(reference).AddYears(yearsToNext);
        }

        private static DateTime Create(DateTime reference)
        {
            return new DateTime(reference.Year, 1, 1);
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            var yearsToNext = reference.Year % _modValue;

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
    }
}
