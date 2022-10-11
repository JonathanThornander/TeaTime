using System.Linq;
using Tea.Core.Expressions;
using Tea.Parser.Services;
using Tea.Parser.Utils;

namespace Tea.Parser
{
    public class TeaParser
    {
        private static TeaParser _instance = new TeaParser();

        private readonly ExpressionParser _parser = new ExpressionParser();
        private readonly ExpressionResolverRouter _router = new ExpressionResolverRouter();

        public static TeaParser Instance { get => _instance; }

        public Expression Parse(string expression)
        {
            var parsed = _parser.Parse(expression);
            var resolver = _router.GetResolver(parsed);

            return resolver.Resolve(parsed);
        }


    }
}
