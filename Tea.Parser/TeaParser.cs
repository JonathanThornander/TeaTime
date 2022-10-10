using System.Linq;
using Tea.Core.Expressions;

namespace Tea.Parser
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
