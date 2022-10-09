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
        private readonly FunctionRouter _functionRouter = new FunctionRouter();
        private readonly ExpressionParser _functionParser = new ExpressionParser();

        public Expression Parse(string expression)
        {
            var parsed = _functionParser.Parse(expression);
            return _functionRouter.Resolve(parsed);
        }
    }
}
