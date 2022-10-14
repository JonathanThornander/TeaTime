using System;
using System.Collections.Generic;
using System.Text;
using Tea.Core.Expressions;
using Tea.Parser.Utils;

namespace Tea.Parser.Resolvers.Constants
{
    internal class WholeHourConstantResolver : ExpressionResolver
    {
        private const string EXPRESSION = "MM:0 SS:0";

        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            return TeaParser.Instance.Parse(EXPRESSION);
        }
    }
}
