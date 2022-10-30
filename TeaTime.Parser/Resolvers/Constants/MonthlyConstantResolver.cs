using TeaTime.Core.Expressions;
using TeaTime.Parser.Utils;

namespace TeaTime.Parser.Resolvers.Constants
{
    internal class MonthlyConstantResolver : ExpressionResolver
    {
        private const string EXPRESSION = "AND(D:1 HH:0 MM:0 SS:0)";

        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            return TeaParser.Instance.Parse(EXPRESSION);
        }
    }
}
