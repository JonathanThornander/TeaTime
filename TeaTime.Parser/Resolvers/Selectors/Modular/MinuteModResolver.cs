using System.Linq;
using TeaTime.Core.Expressions;
using TeaTime.Core.Expressions.Functional;
using TeaTime.Core.Expressions.Selectors.Modular;
using TeaTime.Parser.Utils;

namespace TeaTime.Parser.Resolvers.Selectors.Modular
{
    internal class MinuteModResolver : ExpressionResolver
    {
        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var parsedSelector = (ParsedSelector)parsedExpression;

            var modValues = new RangeParser().ParseRange(parsedSelector.Parameter);

            if (modValues.Length == 1)
            {
                return new MinuteModFunction(modValues[0], parsedSelector.Negated);
            }

            var expressions = modValues.Select(modValue => new MinuteModFunction(modValue, parsedSelector.Negated)).ToArray();

            if (parsedSelector.Negated)
            {
                return new AndFunction(expressions);
            }

            return new OrFunction(expressions);
        }

    }
}
