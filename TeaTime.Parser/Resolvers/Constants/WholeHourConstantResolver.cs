using TeaTime.Core.Expressions;
using TeaTime.Parser.Utils;

namespace TeaTime.Parser.Resolvers.Constants
{
    internal class MidnightConstantResolver : ExpressionResolver
    {
        private const string EXPRESSION = "AND(HH:0 MM:0 SS:0)";

        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            return TeaParser.Instance.Parse(EXPRESSION);
        }
    }
}
