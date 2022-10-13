using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Tea.Core.Expressions;
using Tea.Core.Expressions.Functional;
using Tea.Parser.Utils;

namespace Tea.Parser.Resolvers.Functions
{
    public class AndFunctionResolver : ExpressionResolver
    {
        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var parsedFunction = (ParsedFunction)parsedExpression;

            var teaExpressionString = parsedFunction.Parameters[0];
            string[] expressionTokens = TokensParser.ParseTokens(teaExpressionString);

            var expressions = expressionTokens.Select(token => TeaParser.Instance.Parse(token)).ToArray();

            return new AndFunction(expressions);
        }

        
    }
}
