using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Core.Expressions;

namespace Tea.Core.Parser
{
    public class ExpressionParser
    {

        public ParsedExpressionData Parse(string data)
        {
            ExpressionType type = GetTokenType(data);

            throw new NotImplementedException();

        }

        private ExpressionType GetTokenType(string data)
        {
            var selectorTest = data.IndexOf(':');
            var functionTest = data.IndexOf("(");

            if (selectorTest == -1 && functionTest == -1)
            {
                return ExpressionType.Constant;
            }
            
            if (selectorTest < functionTest || functionTest == -1)
            {
                return ExpressionType.Selector;
            }

            else
            {
                return ExpressionType.Function;
            }
        }

    }

    public record ParsedExpressionData
    {
        public string Name { get; init; }

        public string[] Parameters { get; init; }
    }

    public enum ExpressionType
    {
        Selector,
        Function,
        Constant
    }

}
