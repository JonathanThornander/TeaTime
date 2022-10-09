using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Core.Expressions;

namespace Tea.Core.Parser
{
    public class TeaParser
    {
        private readonly ExpressionParser _parser = new ExpressionParser();

        private readonly FunctionResolver _functionRouter = new FunctionResolver();

        public Expression Parse(string expression)
        {
            var parsed = _parser.Parse(expression);

            return parsed switch
            {
                ParsedFunction => _functionRouter.Resolve((ParsedFunction)parsed),
                _ => throw new Exception()
            };
        }
    }
}
