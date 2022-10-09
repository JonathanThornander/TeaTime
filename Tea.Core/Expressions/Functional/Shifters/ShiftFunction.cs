using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Core.Expressions.Functional.Shifters
{
    public class ShiftFunction : Expression
    {
        private readonly Expression _expression;

        private readonly Func<DateTime, DateTime> shiftBack;
        private readonly Func<DateTime, DateTime> shiftForward;

        public ShiftFunction(Expression expression, Func<DateTime, DateTime> shiftBack, Func<DateTime, DateTime> shiftForward)
        {
            _expression = expression;
            this.shiftBack = shiftBack;
            this.shiftForward = shiftForward;
        }

        protected override DateTime? GetNext(DateTime reference)
        {
            var nextPotential = _expression.NextOccurance(shiftBack.Invoke(reference));

            if (nextPotential == null)
            {
                return null;
            }
            else
            {
                return shiftForward.Invoke((DateTime)nextPotential);
            }
        }

        internal override ValidationResult Validate()
        {
            var innerValidation = _expression.Validate();

            if (innerValidation.Valid == false)
            {
                StringBuilder sb = new();

                sb.AppendLine($"Inner expression of {GetType().Name} are not valid:");
                sb.AppendLine(innerValidation.Message);

                return new ValidationResult(false, sb.ToString());
            }

            return new ValidationResult(true);
        }
    }

    public class ShiftYearsFunction : ShiftFunction
    {
        public ShiftYearsFunction(Expression expression, int shift) : base(
            expression,
            shiftBack: (date) => { return date.AddYears(-shift); },
            shiftForward: (date) => { return date.AddYears(shift); })
        {
        }
    }

    public class ShiftMonthsFunction : ShiftFunction
    {
        public ShiftMonthsFunction(Expression expression, int shift, bool bleed = false) : base(
            expression,
            shiftBack: (date) => { return date.AddMonths(-shift); },
            shiftForward: (date) => { return ShiftForward(shift, date, bleed); })
        {
        }

        private static DateTime ShiftForward(int shift, DateTime date, bool bleed)
        {
            var result = date.AddMonths(shift);

            if (DateTime.DaysInMonth(result.Year, result.Month) < date.Day)
            {
                if (bleed == false)
                {
                    return new DateTime(result.Year, result.Month, 1).AddYears(1);
                }
                
                while (DateTime.DaysInMonth(result.Year, result.Month) < date.Day)
                {
                    result = result.AddDays(1);
                }
            }

            return result;
        }
    }

    public class ShiftDaysFunction : ShiftFunction
    {
        public ShiftDaysFunction(Expression expression, int shift) : base(
            expression,
            shiftBack: (date) => { return date.AddDays(-shift); },
            shiftForward: (date) => { return date.AddDays(shift); })
        {
        }
    }

    public class ShiftHoursFunction : ShiftFunction
    {
        public ShiftHoursFunction(Expression expression, int shift) : base(
            expression,
            shiftBack: (date) => { return date.AddHours(-shift); },
            shiftForward: (date) => { return date.AddHours(shift); })
        {
        }
    }

    public class ShiftMinutesFunction : ShiftFunction
    {
        public ShiftMinutesFunction(Expression expression, int shift) : base(
            expression,
            shiftBack: (date) => { return date.AddMinutes(-shift); },
            shiftForward: (date) => { return date.AddMinutes(shift); })
        {
        }
    }

    public class ShiftSecondsFunction : ShiftFunction
    {
        public ShiftSecondsFunction(Expression expression, int shift) : base(
            expression,
            shiftBack: (date) => { return date.AddSeconds(-shift); },
            shiftForward: (date) => { return date.AddSeconds(shift); })
        {
        }
    }
}
