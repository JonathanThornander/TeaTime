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

        public ParsedExpression Parse(string data)
        {
            ExpressionType type = GetTokenType(data);

            if (type is ExpressionType.Function)
            {
                return ParseFunction(data);
            }
            else if (type is ExpressionType.Selector)
            {
                return ParseSelector(data);
            }
            else
            {
                return ParseConstant(data);
            }

        }

        private static ParsedExpression ParseConstant(string data)
        {
            return new ParsedConstant()
            {
                Name = data,
            };
        }

        private static ParsedExpression ParseSelector(string data)
        {
            var negate = false;
            var name = "";

            var beforeColon = data.Split(':')[0];

            if (beforeColon.StartsWith("!"))
            {
                negate = true;
                name = beforeColon[1..];
            }
            else
            {
                name = beforeColon;
            }

            var parameter = data.Split(':')[1];

            return new ParsedSelector()
            {
                Name = name,
                Negated = negate,
                Parameter = parameter,
            };
        }

        private static ParsedExpression ParseFunction(string data)
        {
            var name = data.Split('(')[0];

            var insideParentheses = data.Split('(')[1].Split(')')[0];
            var parameters = insideParentheses.Split(',', StringSplitOptions.TrimEntries);

            return new ParsedFunction()
            {
                Name = name,
                Parameters = parameters,
            };
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

    public record ParsedExpression
    {
        public string Name { get; init; }
    }

    public record ParsedFunction : ParsedExpression
    {
        public string[] Parameters { get; init; }
    }

    public record ParsedSelector : ParsedExpression
    {
        public string Parameter { get; init; }

        public bool Negated { get; set; }
    }

    public record ParsedConstant : ParsedExpression
    {
    }

    public enum ExpressionType
    {
        Selector,
        Function,
        Constant
    }

}
