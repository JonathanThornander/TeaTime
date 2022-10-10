using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Parser;
using Tea.Parser.Resolvers.Selectors;
using Tea.Parser.Utils;
using Xunit;

namespace Tea.Tests.Resolvers.Selectors
{
    public class DayOfMonthResolverTests
    {
        [Fact]
        public void Test1()
        {
            var input = new ParsedSelector { Name = "D", Negated = false, Parameter = "1-6" };
            var resolver = new DayOfMonthSelectorResolver();

            // Act
            var result = resolver.Resolve(input);

            // Assert
            Assert.True(true);
        }
    }
}
