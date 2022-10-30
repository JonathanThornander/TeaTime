using System.Linq;
using TeaTime.Core.Expressions;
using TeaTime.Core.Expressions.Functional;
using TeaTime.Parser.Exceptions;
using TeaTime.Parser.Utils;

namespace TeaTime.Parser.Resolvers.Functions
{
    public class AndFunctionResolver : ExpressionResolver
    {
        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var parsedFunction = (ParsedFunction)parsedExpression;

            if (parsedFunction.Parameters.Length != 1) throw new TeaParserException("AND-function requires exactly 1 parameter");

            var teaExpressionString = parsedFunction.Parameters[0];
            string[] expressionTokens = TokensParser.ParseTokens(teaExpressionString);

            if (expressionTokens.Length == 0) throw new TeaParserException("At least one token is required in AND-function");

            var expressions = expressionTokens.Select(token => TeaParser.Instance.Parse(token)).ToArray();

            return new AndFunction(expressions);
        }
    }
}
