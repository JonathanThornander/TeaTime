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

        public DayOfWeekSelector(DayOfWeek dayOfWeek, bool negate = false) : base(negate)
        {
            _dayOfWeek = dayOfWeek;
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

        private static DateTime Create(DateTime reference)
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
