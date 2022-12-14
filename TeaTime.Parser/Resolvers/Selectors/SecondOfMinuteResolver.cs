using System.Linq;
using TeaTime.Core.Expressions;
using TeaTime.Core.Expressions.Functional;
using TeaTime.Core.Expressions.Selectors;
using TeaTime.Parser.Utils;

namespace TeaTime.Parser.Resolvers.Selectors
{
    internal class SecondOfMinuteResolver : ExpressionResolver
    {
        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var parsedSelector = (ParsedSelector)parsedExpression;

            var days = new RangeParser().ParseRange(parsedSelector.Parameter);

            if (days.Length == 1)
            {
                return new SecondOfMinuteSelector(days[0], parsedSelector.Negated);
            }

            var expressions = days.Select(day => new SecondOfMinuteSelector(day, parsedSelector.Negated)).ToArray();

            if (parsedSelector.Negated)
            {
                return new AndFunction(expressions);
            }

            return new OrFunction(expressions);
        }
    }
}
