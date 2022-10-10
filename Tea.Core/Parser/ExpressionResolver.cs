using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Core.Expressions;

namespace Tea.Core.Parser
{
    public abstract class ExpressionResolver
    {
        public abstract bool ResolvesFor(ParsedExpression parsed);

        public abstract Expression Resolve(ParsedExpression parsedFunction);
    }
}
