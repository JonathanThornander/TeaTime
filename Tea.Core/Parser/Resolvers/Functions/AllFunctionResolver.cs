using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Core.Expressions;

namespace Tea.Core.Parser.Resolvers.Functions
{
    public class AllFunctionResolver : ExpressionResolver
    {
        private const string FunctionName = "ALL";


        public override Expression Resolve(ParsedExpression parsedFunction)
        {
            throw new NotImplementedException();
        }

        public override bool ResolvesFor(ParsedExpression parsed)
        {
            if (parsed is not ParsedFunction)
            {
                return false;
            }

            if (parsed.Name.Equals(FunctionName, StringComparison.CurrentCultureIgnoreCase) == false)
            {
                return false;
            }

            return true;
        }
    }
}
