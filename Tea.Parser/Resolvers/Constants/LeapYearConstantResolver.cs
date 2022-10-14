using System;
using System.Collections.Generic;
using System.Text;
using Tea.Core.Expressions;
using Tea.Parser.Utils;

namespace Tea.Parser.Resolvers.Constants
{
    internal class LeapYearConstantResolver : ExpressionResolver
    {
        private const string LEAPYEAR = "OR(AND(Y%:4 !Y%:100) AND(Y%:4 Y%:100 Y%:400))";

        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            return TeaParser.Instance.Parse(LEAPYEAR);
        }
    }
}
