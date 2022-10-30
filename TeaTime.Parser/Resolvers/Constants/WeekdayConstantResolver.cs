using TeaTime.Core.Expressions;
using TeaTime.Parser.Utils;

namespace TeaTime.Parser.Resolvers.Constants
{
    internal class WeekdayConstantResolver : ExpressionResolver
    {
        private const string EXPRESSION = "OR(W:Monday-Friday)";

        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            return TeaParser.Instance.Parse(EXPRESSION);
        }
    }
}
