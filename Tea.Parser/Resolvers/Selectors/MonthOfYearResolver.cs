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
    internal class MonthOfYearResolver : ExpressionResolver
    {
        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var parsedSelector = (ParsedSelector)parsedExpression;

            var days = new RangeParser().ParseRange(parsedSelector.Parameter, new MonthToIntTranslator());

            if (days.Length == 1)
            {
                return new MonthOfYearSelector(days[0], parsedSelector.Negated);
            }

            var expressions = days.Select(day => new MonthOfYearSelector(day, parsedSelector.Negated)).ToArray();

            if (parsedSelector.Negated)
            {
                return new AndFunction(expressions);
            }

            return new OrFunction(expressions);
        }
    }

    internal class MonthToIntTranslator : INameToIntTranslator
    {
        int INameToIntTranslator.NameToInt(string name)
        {
            switch(name.ToUpper())
            {
                case "1":
                case "JAN":
                case "JANUARY":
                    return 1;
                case "2":
                case "FEB":
                case "FEBRUARY":
                    return 2;
                case "3":
                case "MAR":
                case "MARS":
                    return 3;
                case "4":
                case "APR":
                case "APRIL":
                    return 4;
                case "5":
                case "MAY":
                    return 5;
                case "6":
                case "JUN":
                case "JUNE":
                    return 6;
                case "7":
                case "JUL":
                case "JULY":
                    return 7;
                case "8":
                case "AUG":
                case "AUGUSTI":
                    return 8;
                case "9":
                case "SEP":
                case "SEPTEMBER":
                    return 9;
                case "10":
                case "OCT":
                case "OCTOBER":
                    return 10;
                case "11":
                case "NOV":
                case "NOVEMBER":
                    return 11;
                case "12":
                case "DEC":
                case "DECEMBER":
                    return 12;
                default:
                    throw new Exception($"The month '{name}' was not recognized");
            }
        }
    }
}
