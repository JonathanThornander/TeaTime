using System;
using Tea.Core.LINQExtensions;

namespace Tea.Core.Expressions.Selectors.NthWeekday
{
    public class NthLastWeekdaySelector : NthWeekdayBaseSelector
    {
        private readonly int _nthValue;
        private readonly DayOfWeek _dayOfWeek;

        public NthLastWeekdaySelector(int nthValue, DayOfWeek dayOfWeek, bool negate = false) : base(negate)
        {
            _nthValue = nthValue;
            _dayOfWeek = dayOfWeek;
        }

        protected override DateTime Create(DateTime reference)
        {
            var lastDayOfMont = new DateTime(reference.Year, reference.Month, DateTime.DaysInMonth(reference.Year, reference.Month));
            var lastWeekday = lastDayOfMont.Previous(_dayOfWeek);
            var next = lastWeekday.AddDays(7 * (_nthValue + 1));

            return next;
        }

        internal override string GetSignature() => $"-{_nthValue}:{_dayOfWeek}";

        internal override ValidationResult Validate()
        {
            if (_nthValue > -1) return new ValidationResult(false, "Nth value must be a negative integer");

            return new ValidationResult(true);
        }
    }
}
