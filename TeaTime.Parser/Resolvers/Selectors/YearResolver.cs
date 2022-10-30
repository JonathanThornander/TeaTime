using System.Linq;
using TeaTime.Core.Expressions;
using TeaTime.Core.Expressions.Functional;
using TeaTime.Core.Expressions.Selectors;
using TeaTime.Parser.Utils;

namespace TeaTime.Parser.Resolvers.Selectors
{
    internal class YearResolver : ExpressionResolver
    {
        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var parsedSelector = (ParsedSelector)parsedExpression;

            var years = new RangeParser().ParseRange(parsedSelector.Parameter);

            if (years.Length == 1)
            {
                return new YearSelector(years[0], parsedSelector.Negated);
            }

            var expressions = years.Select(year => new YearSelector(year, parsedSelector.Negated)).ToArray();

            if (parsedSelector.Negated)
            {
                return new AndFunction(expressions);
            }

            return new OrFunction(expressions);
        }
    }
}
