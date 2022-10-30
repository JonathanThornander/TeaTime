using TeaTime.Core.Expressions;

namespace TeaTime.Parser.Utils
{
    public abstract class ExpressionResolver
    {
        public abstract Expression Resolve(ParsedExpression parsedExpression);
    }

}
