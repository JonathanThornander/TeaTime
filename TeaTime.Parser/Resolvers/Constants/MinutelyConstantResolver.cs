using TeaTime.Core.Expressions;
using TeaTime.Parser.Utils;

namespace TeaTime.Parser.Resolvers.Constants
{
    internal class MinutelyConstantResolver : ExpressionResolver
    {
        private const string EXPRESSION = "AND(SS:0)";

        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            return TeaParser.Instance.Parse(EXPRESSION);
        }
    }
}
