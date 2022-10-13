using System;
using System.Collections.Generic;
using System.Text;

namespace Tea.Parser.Utils
{
    internal class TokensParser
    {
        internal static string[] ParseTokens(string teaExpressionString)
        {
            var tokens = new List<string>();
            var sb = new StringBuilder();
            var depth = 0;

            using var charEnumerator = teaExpressionString.GetEnumerator();

            while (charEnumerator.MoveNext())
            {
                if (charEnumerator.Current.Equals('('))
                {
                    depth++;
                }
                else if (charEnumerator.Current.Equals(')'))
                {
                    depth--;
                }
                else if (charEnumerator.Current.Equals(' '))
                {
                    if (depth == 0)
                    {
                        tokens.Add(sb.ToString().Trim());
                        sb.Clear();
                    }
                }

                sb.Append(charEnumerator.Current);
            }

            if (sb.Length > 0)
            {
                tokens.Add(sb.ToString().Trim());
            }

            return tokens.ToArray();
        }
    }
}
