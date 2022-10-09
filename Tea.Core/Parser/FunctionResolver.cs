using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Core.Expressions;
using Tea.Core.Parser.Implementations;

namespace Tea.Core.Parser
{
    public class FunctionRouter
    {
        private readonly AllFunctionResolver allFunctionResolver = new();

        public Expression Resolve(ParsedExpressionData parsedFunction)
        {

            if (parsedFunction.Name.Equals("ALL", StringComparison.CurrentCultureIgnoreCase)) return allFunctionResolver.Resolve(parsedFunction);
            else throw new NotImplementedException();
        }
    }
}
