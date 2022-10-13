using System.Linq;
using Tea.Core.Expressions;
using Tea.Core.Expressions.Functional;
using Tea.Core.Expressions.Selectors.Modular;
using Tea.Parser.Utils;

namespace Tea.Parser.Resolvers.Selectors.Modular
{
    internal class MonthModResolver : ExpressionResolver
    {
        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var parsedSelector = (ParsedSelector)parsedExpression;

            var modValues = new RangeParser().ParseRange(parsedSelector.Parameter);

            if (modValues.Length == 1)
            {
                return new MonthModFunction(modValues[0], parsedSelector.Negated);
            }

            var expressions = modValues.Select(modValue => new MonthModFunction(modValue, parsedSelector.Negated)).ToArray();

            if (parsedSelector.Negated)
            {
                return new AndFunction(expressions);
            }

            return new OrFunction(expressions);
        }

    }
}
