using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Parser.Utils;
using Xunit;

namespace Tea.Tests.Utils
{
    public class RangeParserTests
    {
        [Fact]
        public void ParseRange_1_through_6_Returns_6_ints_AscendingOrder()
        {
            var input = "1-6";

            // Act
            var range = new RangeParser().ParseRange(input);

            // Assert
            Assert.True(range.Length == 6);
            Assert.Equal(Enumerable.Range(1, 6).ToArray(), range);
        }

        [Fact]
        public void ParseRange_6_through_1_Returns_6_ints_AscendingOrder()
        {
            var input = "6-1";

            // Act
            var range = new RangeParser().ParseRange(input);

            // Assert
            Assert.True(range.Length == 6);
            Assert.Equal(Enumerable.Range(1, 6).ToArray(), range);
        }
    }
}
