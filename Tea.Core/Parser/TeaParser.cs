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

        public Expression Parse(string expression)
        {
            var parsed = _parser.Parse(expression);
            var resolver = Container.Resolvers.Where(resolver => resolver.ResolvesFor(parsed)).First();
            return resolver.Resolve(parsed);
        }
    }
}
