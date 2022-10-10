using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tea.Core.Expressions;
using Tea.Core.Expressions.Functional;
using Tea.Core.Expressions.Selectors;

namespace Tea.Core.Parser.Resolvers.Selectors
{
    internal class DayOfMonthSelectorResolver : ExpressionResolver
    {
        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var parsedSelector = (ParsedSelector)parsedExpression;
            var days = ParseRange(parsedSelector.Parameter);

            if (days.Length == 1)
            {
                return new DayOfMonthSelector(days[0], parsedSelector.Negated);
            }

            var expressions = days.Select(day => new DayOfMonthSelector(day, parsedSelector.Negated)).ToArray();
            return new OrFunction(expressions);
        }

        public override bool ResolvesFor(ParsedExpression parsed)
        {
            return parsed.Name.Equals("D", StringComparison.CurrentCultureIgnoreCase);
        }

        private int[] ParseRange(string parameter)
        {
            if (parameter.Contains("-"))
            {
                throw new NotImplementedException("Not yet implemented");
            }

            else
            {
                var value = int.Parse(parameter);
                return new int[] { value };
            }
        }
    }
}
