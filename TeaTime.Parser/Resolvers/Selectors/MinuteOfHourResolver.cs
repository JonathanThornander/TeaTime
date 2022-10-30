using System.Linq;
using TeaTime.Core.Expressions;
using TeaTime.Core.Expressions.Functional;
using TeaTime.Core.Expressions.Selectors;
using TeaTime.Parser.Utils;

namespace TeaTime.Parser.Resolvers.Selectors
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

            if (parsedSelector.Negated)
            {
                return new AndFunction(expressions);
            }

            return new OrFunction(expressions);
        }
    }
}
