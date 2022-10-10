using System;
using System.Linq;
using Tea.Core.Expressions;
using Tea.Core.Expressions.Functional;

namespace Tea.Parser.Resolvers.Functions
{
    public class AllFunctionResolver : ExpressionResolver
    {
        private const string FunctionName = "ALL";

        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var parsedFunction = (ParsedFunction)parsedExpression;

            var teaExpressionString = parsedFunction.Parameters[0];
            var expressionTokens = teaExpressionString.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var expressions = expressionTokens.Select(token => Container.Parser.Parse(token)).ToArray();

            return new AndFunction(expressions);
        }

        public override bool ResolvesFor(ParsedExpression parsed)
        {
            if (parsed is ParsedFunction == false)
            {
                return false;
            }

            if (parsed.Name.Equals(FunctionName, StringComparison.CurrentCultureIgnoreCase) == false)
            {
                return false;
            }

            return true;
        }
    }
}
