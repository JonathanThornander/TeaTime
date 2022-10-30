using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeaTime.Parser.Exceptions;

namespace TeaTime.Parser.Utils
{
    public class ExpressionParser
    {
        public ParsedExpression Parse(string data)
        {
            try
            {
                ValidateParenthesis(data);

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
            catch (Exception ex)
            {
                if (ex is TeaParserException)
                {
                    throw new TeaParserException($"The expression is invalid. Could not parse '{data}'", ex);
                }
                throw new TeaParserException($"The expression is invalid. Could not parse '{data}'");
            }
        }

        private static void ValidateParenthesis(string data)
        {
            var numOpen = data.Count(c => c == '(');
            var numClosed = data.Count(c => c == ')');

            if (numClosed != numOpen)
            {
                throw new TeaParserException($"Inconsistent parenthesis. Found {numOpen} opening and {numClosed} closing parenthesis");
            }
        }

        private static ParsedConstant ParseConstant(string data)
        {
            return new ParsedConstant()
            {
                Name = data,
            };
        }

        private static ParsedSelector ParseSelector(string data)
        {
            var negate = false;
            var name = string.Empty;

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

            if (string.IsNullOrWhiteSpace(name)) throw new TeaParserException("The selector name is empty");

            var parameter = data.Split(':')[1];

            return new ParsedSelector()
            {
                Name = name,
                Negated = negate,
                Parameter = parameter,
            };
        }

        private static ParsedFunction ParseFunction(string data)
        {
            var name = data.Split('(')[0];

            if (string.IsNullOrWhiteSpace(name)) throw new TeaParserException($"No name provided for function '{data}'");

            var openingParenthesis = data.IndexOf('(') + 1;
            var closingParenthesis = data.LastIndexOf(')');

            var insideParentheses = data[openingParenthesis..closingParenthesis];
            string[] parameters = ParseFunctionParameters(insideParentheses);

            return new ParsedFunction()
            {
                Name = name,
                Parameters = parameters,
            };
        }

        private static string[] ParseFunctionParameters(string insideParentheses)
        {
            List<string> parameters = new List<string>();

            var depth = 0;
            var sb = new StringBuilder();

            using var charEnumerator = insideParentheses.GetEnumerator();
            while (charEnumerator.MoveNext())
            {
                if (charEnumerator.Current == '(')
                {
                    depth++;
                }
                else if (charEnumerator.Current == ')')
                {
                    depth--;
                }

                if (charEnumerator.Current == ',' && depth == 0)
                {
                    parameters.Add(sb.ToString().Trim());
                    sb.Clear();
                }
                else
                {
                    sb.Append(charEnumerator.Current);
                }
            }

            parameters.Add(sb.ToString().Trim());

            return parameters.ToArray();
        }

        private ExpressionType GetTokenType(string data)
        {
            var selectorTest = data.IndexOf(':');
            var functionTest = data.IndexOf("(");

            if (selectorTest == -1 && functionTest == -1)
            {
                return ExpressionType.Constant;
            }

            if ((selectorTest < functionTest || functionTest == -1) && selectorTest != -1)
            {
                return ExpressionType.Selector;
            }

            else
            {
                return ExpressionType.Function;
            }
        }

    }

    public class ParsedExpression
    {
        public string Name { get; set; }
    }

    public class ParsedFunction : ParsedExpression
    {
        public string[] Parameters { get; set; }
    }

    public class ParsedSelector : ParsedExpression
    {
        public string Parameter { get; set; }

        public bool Negated { get; set; }
    }

    public class ParsedConstant : ParsedExpression
    {
    }

    public enum ExpressionType
    {
        Selector,
        Function,
        Constant
    }

}
