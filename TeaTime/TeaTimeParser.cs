using System;
using TeaTime.Core.Expressions;
using TeaTime.Parser;

namespace TeaTime
{
    public class TeaTimeParser
    {
        private readonly TeaParser _parser = new TeaParser();

        /// <summary>
        /// Parses a TeaExpression. A return value indicates whether the conversion succeeded
        /// </summary>
        /// <param name="parsed"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool TryParse(out Expression parsed, string expression)
        {
            try
            {
                parsed = Parse(expression);
                return true;
            }
            catch
            {
                parsed = new NullExpression();
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        /// <exception cref="TeaTimeException"></exception>
        public Expression Parse(string expression)
        {
            var input = $"AND({expression})";

            try
            {
                return _parser.Parse(input);
            }
            catch (Exception ex)
            {
                throw new TeaTimeException($"Failed to parse expression: {ex.Message}", ex);
            }
        }

    }
}
