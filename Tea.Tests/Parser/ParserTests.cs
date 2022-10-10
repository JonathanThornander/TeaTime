using Tea.Core.Parser;
using Tea.Core.Parser.Resolvers.Functions;

namespace Tea.Tests.Parser
{
    public class ParserTests
    {
        [Fact]
        public void ParseOne()
        {
            TeaParser parser = new TeaParser();
            parser.Parse("ALL(D:25 M:18, ANY(D:1, D:2), D:19)");
        }
    }
}