using Tea.Core.Expressions;
using Tea.Parser.Utils;

namespace Tea.Parser.Resolvers.Constants
{
    internal class YearlyConstantResolver : ExpressionResolver
    {
        private const string EXPRESSION = "AND(M:1 D:1 HH:0 MM:0 SS:0)";

        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            return TeaParser.Instance.Parse(EXPRESSION);
        }
    }
}
