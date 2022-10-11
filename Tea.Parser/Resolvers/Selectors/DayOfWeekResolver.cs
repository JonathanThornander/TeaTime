using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tea.Core.Expressions;
using Tea.Core.Expressions.Functional;
using Tea.Core.Expressions.Selectors;
using Tea.Parser.Utils;

namespace Tea.Parser.Resolvers.Selectors
{
    internal class DayOfWeekResolver : ExpressionResolver
    {
        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var parsedSelector = (ParsedSelector)parsedExpression;

            var days = new RangeParser().ParseRange(parsedSelector.Parameter, new WeekDayTranslator())
                .Select(day => ((DayOfWeek)day))
                .ToArray();

            if (days.Length == 1)
            {
                return new DayOfWeekSelector(days[0], parsedSelector.Negated);
            }

            var expressions = days.Select(day => new DayOfWeekSelector(day, parsedSelector.Negated)).ToArray();

            if (parsedSelector.Negated)
            {
                return new AndFunction(expressions);
            }

            return new OrFunction(expressions);
        }
    }

    internal class WeekDayTranslator : INameToIntTranslator
    {
        int INameToIntTranslator.NameToInt(string name)
        {
            if (int.TryParse(name, out int value)) return value;

            switch (name.ToUpper())
            {
                case "SUNDAY":
                case "SUN":
                    return 0;
                case "MONDAY":
                case "MON":
                    return 1;
                case "TUESDAY":
                case "TUE":
                    return 2;
                case "WEDNESDAY":
                case "WED":
                    return 3;
                case "THURSDAY":
                case "THU":
                    return 4;
                case "FRIDAY":
                case "FRI":
                    return 5;
                case "SATURDAY":
                case "SAT":
                    return 6;
                default:
                    throw new ArgumentException($"The name {name} does not translate to an integer");
            }
        }
    }
}
