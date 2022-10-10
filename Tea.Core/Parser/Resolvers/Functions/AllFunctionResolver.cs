using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Core.Expressions;
using Tea.Core.Expressions.Functional;

namespace Tea.Core.Parser.Resolvers.Functions
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
            if (parsed is not ParsedFunction)
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
