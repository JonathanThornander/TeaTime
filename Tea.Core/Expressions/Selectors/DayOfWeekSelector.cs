using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Core.Expressions.Selectors
{
    public class DayOfWeekSelector : SelectorExpression
    {
        private readonly DayOfWeek _dayOfWeek;
        private readonly bool _negated;

        public DayOfWeekSelector(DayOfWeek dayOfWeek, bool negate = false) : base(negate)
        {
            _dayOfWeek = dayOfWeek;
            _negated = negate;
        }

        public DayOfWeekSelector(int dayOfWeek, bool negate = false) : base(negate)
        {
            _dayOfWeek = (DayOfWeek)dayOfWeek;
        }

        internal override string GetSignature()
        {
            var prefix = _negated ? "!" : ""; 
            return $"{prefix}W:{(int)_dayOfWeek}";
        }

        protected override DateTime? GetNext(DateTime reference)
        {
            if (reference.DayOfWeek == _dayOfWeek)
            {
                return reference;
            }
            else
            {
                return Forward(reference);
            }
        }

        private DateTime? Forward(DateTime reference)
        {
            DateTime current = Create(reference);

            while (current.DayOfWeek != _dayOfWeek)
            {
                current = current.AddDays(1);
            }

            return current;
        }

        internal override DateTime Create(DateTime reference)
        {
            return new DateTime(reference.Year, reference.Month, reference.Day);
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            if (reference.DayOfWeek == _dayOfWeek)
            {
                return Create(reference).AddDays(1);
            }
            else
            {
                return reference;
            }
        }

        internal override ValidationResult Validate()
        {
            return new ValidationResult(true);
        }
    }
}
