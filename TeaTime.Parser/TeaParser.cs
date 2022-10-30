using System.Runtime.CompilerServices;
using TeaTime.Core.Expressions;
using TeaTime.Parser.Utils;

[assembly: InternalsVisibleTo("TeaTime")]

namespace TeaTime.Parser
{
    internal class TeaParser
    {
        private static readonly TeaParser _instance = new TeaParser();

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
