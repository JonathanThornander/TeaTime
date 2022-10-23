using Tea.Core.Expressions;
using Tea.Parser;
using Tea.Parser.Utils;

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
