using System;
using System.Collections.Generic;
using System.Text;
using Tea.Core.Expressions;
using Tea.Parser;
using Tea.Parser.Utils;

namespace TeaTime.Parser.Resolvers.Constants
{
    internal class WeekendConstantResolver : ExpressionResolver
    {
        private const string EXPRESSION = "OR(W:Saturday W:Sunday)";

        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            return TeaParser.Instance.Parse(EXPRESSION);
        }
    }
}
