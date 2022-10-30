using TeaTime.Core.Expressions;
using TeaTime.Core.Expressions.Selectors.Special;
using TeaTime.Parser.Exceptions;
using TeaTime.Parser.Utils;

namespace TeaTime.Parser.Resolvers.Selectors
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
