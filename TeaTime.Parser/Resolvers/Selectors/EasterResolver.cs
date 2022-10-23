using Tea.Core.Expressions;
using Tea.Core.Expressions.Selectors.Special;
using Tea.Parser.Exceptions;
using Tea.Parser.Utils;

namespace Tea.Parser.Resolvers.Selectors
{
    internal class EasterResolver : ExpressionResolver
    {
        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var parsedSelector = (ParsedSelector)parsedExpression;

            return parsedSelector.Parameter.ToUpperInvariant() switch
            {
                "ORTHODOX" => new OrthodoxEasterSelector(parsedSelector.Negated),
                "CATHOLIC" => new CatholicEasterSelector(parsedSelector.Negated),

                _ => throw new TeaParserException($"No easter calendar matches '{parsedSelector.Name}'")
            };
        }
    }
}
