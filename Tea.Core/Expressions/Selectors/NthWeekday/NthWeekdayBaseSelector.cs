using System;
using System.Collections.Generic;
using System.Text;
using Tea.Core.LINQExtensions;

namespace Tea.Core.Expressions.Selectors.NthWeekday
{
    public abstract class NthWeekdayBaseSelector : SelectorExpression
    {
        public NthWeekdayBaseSelector(bool negate = false) : base(negate)
        {
        }

        protected override DateTime? GetNext(DateTime reference)
        {
            var current = Create(reference);

            if (current < reference && current.Date == reference.Date)
            {
                return reference;
            }

            while (current < reference)
            {
                current = Create(reference.AddMonths(1));

                if (current.Month == reference.Month)
                {
                    current = Create(reference.AddMonths(2));
                }
            }

            return current;
        }

        protected override DateTime? GetNextNegate(DateTime reference)
        {
            var next = GetNext(reference);

            if (reference == next)
            {
                if (next is null == false)
                {
                    return ((DateTime)next).AddDays(1);
                }
            }

            return reference;
        }

        protected abstract DateTime Create(DateTime reference);
    }
}
