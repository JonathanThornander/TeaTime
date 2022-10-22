using System;
using System.Collections.Generic;
using System.Text;
using Tea.Core.LINQExtensions;

namespace Tea.Core.Expressions.Selectors.NthWeekday
{
    public class NthNextWeekdaySelector : NthWeekdayBaseSelector
    {
        private readonly int _nthValue;
        private readonly DayOfWeek _dayOfWeek;

        public NthNextWeekdaySelector(int nthValue, DayOfWeek dayOfWeek, bool negate = false) : base(negate)
        {
            _nthValue = nthValue;
            _dayOfWeek = dayOfWeek;
        }

        protected override DateTime Create(DateTime reference)
        {
            var firstDayOfMonth = new DateTime(reference.Year, reference.Month, 1);
            var firstWeekday = firstDayOfMonth.Next(_dayOfWeek);
            var next = firstWeekday.AddDays(7 * (_nthValue - 1));

            return next;
        }

        internal override string GetSignature() => $"{_nthValue}:{_dayOfWeek}";

        internal override ValidationResult Validate()
        {
            if (_nthValue < 1) return new ValidationResult(false, "Nth value must be a positive integer");

            return new ValidationResult(true);
        }
    }
}
