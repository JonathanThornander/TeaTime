using Tea.Core.Expressions;

namespace Tea.Parser
{
    public abstract class ExpressionResolver
    {
        public abstract bool ResolvesFor(ParsedExpression parsed);

        public abstract Expression Resolve(ParsedExpression parsedFunction);
    }
}
