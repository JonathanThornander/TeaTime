using Tea.Core.Parser;

namespace Tea.Tests.Parser
{
    public class ParserTests
    {
        [Fact]
        public void ParseOne()
        {
            TeaParser parser = new TeaParser();
            parser.Parse("D:25");
        }
    }
}