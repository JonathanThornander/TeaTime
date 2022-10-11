using System;
using System.Linq;
using Tea.Core.Expressions;
using Tea.Core.Expressions.Functional;
using Tea.Parser.Utils;

namespace Tea.Parser.Resolvers.Functions
{
    public class OrFunctionResolver : ExpressionResolver
    {
        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var parsedFunction = (ParsedFunction)parsedExpression;

            var teaExpressionString = parsedFunction.Parameters[0];
            var expressionTokens = teaExpressionString.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var expressions = expressionTokens.Select(token => TeaParser.Instance.Parse(token)).ToArray();

            return new OrFunction(expressions);
        }
    }
}
