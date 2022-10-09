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
    public abstract class FunctionResolver
    {
        public abstract Func<string, bool> ResolvedFor { get; }

        public abstract Expression Resolve(ParsedFunction parsedFunction);
    }
}
