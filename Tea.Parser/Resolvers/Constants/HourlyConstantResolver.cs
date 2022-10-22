using Tea.Core.Expressions;
using Tea.Parser.Utils;

namespace Tea.Parser.Resolvers.Constants
{
    internal class HourlyConstantResolver : ExpressionResolver
    {
        private const string EXPRESSION = "AND(MM:0 SS:0)";

        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            return TeaParser.Instance.Parse(EXPRESSION);
        }
    }
}
