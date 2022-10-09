using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Core.Expressions;

namespace Tea.Core.Parser.Implementations
{
    internal class AllFunctionResolver : FunctionResolver
    {
        public override Func<string, bool> ResolvedFor => (val) => val.Equals("ANY", StringComparison.CurrentCultureIgnoreCase);

        public override Expression Resolve(ParsedFunction parsedFunction)
        {
            throw new NotImplementedException();
        }
    }
}
