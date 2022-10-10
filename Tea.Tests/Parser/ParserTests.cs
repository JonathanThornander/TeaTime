using Tea.Core.Parser;
using Tea.Core.Parser.Resolvers.Functions;

namespace Tea.Tests.Parser
{
    public class ParserTests
    {
        [Fact]
        public void ParseOne()
        {
            var resolvers = new List<ExpressionResolver>()
            {
                new AllFunctionResolver()
            };

            TeaParser parser = new TeaParser(resolvers);
            parser.Parse("SWITCH(D:25 M:18, Sumberge, D:19)");
        }
    }
}