using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Tea.Core.Expressions;
using Tea.Core.Expressions.Functional;
using Tea.Parser.Exceptions;
using Tea.Parser.Utils;

namespace Tea.Parser.Resolvers.Functions
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
