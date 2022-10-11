using System.Linq;
using Tea.Core.Expressions;
using Tea.Core.Expressions.Functional;
using Tea.Core.Expressions.Selectors;
using Tea.Parser.Utils;

namespace Tea.Parser.Resolvers.Selectors
{
    internal class MinuteOfHourResolver : ExpressionResolver
    {
        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var parsedSelector = (ParsedSelector)parsedExpression;

            var days = new RangeParser().ParseRange(parsedSelector.Parameter);

            if (days.Length == 1)
            {
                return new MinuteOfHourSelector(days[0], parsedSelector.Negated);
            }

            var expressions = days.Select(day => new MinuteOfHourSelector(day, parsedSelector.Negated)).ToArray();

            return new OrFunction(expressions);
        }
    }
}
