using System;
using Tea.Core.Expressions;
using Tea.Parser;

namespace TeaTime
{
    public class TeaTimeParser
    {
        private readonly TeaParser _parser = new TeaParser();

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
