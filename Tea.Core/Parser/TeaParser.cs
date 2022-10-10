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

        private IEnumerable<ExpressionResolver> _resolvers;

        public TeaParser(IEnumerable<ExpressionResolver> resolvers)
        {
            _resolvers = resolvers;
        }

        public Expression Parse(string expression)
        {
            var parsed = _parser.Parse(expression);
            var resolver = _resolvers.Where(resolver => resolver.ResolvesFor(parsed)).First();
            return resolver.Resolve(parsed);
        }
    }
}
