using Tea.Core.Expressions;

namespace Tea.Parser.Utils
{
    public abstract class ExpressionResolver
    {
        public abstract Expression Resolve(ParsedExpression parsedExpression);
    }

}
