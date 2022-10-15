using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Parser;
using Xunit;

namespace Tea.Tests.CompleteFlow
{
    public class DayOfMonthSelectorTests
    {
        [Fact]
        public void Test()
        {
            var parser = TeaParser.Instance;
            var reference = DateTime.Parse("2000-1-1");
            var input = "D:1 HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(reference, reference.AddMonths(12));
            var count = ocus.Count();

            // Assert
            Assert.Equal(12, count);
        }
    }
}
