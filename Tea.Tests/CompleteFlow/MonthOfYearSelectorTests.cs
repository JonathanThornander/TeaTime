using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaTime;
using Xunit;

namespace Tea.Tests.CompleteFlow
{
    public class MonthOfYearSelectorTests
    {
        [Fact]
        public void FirstJanuary_For_10_Years_Returns_10_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2010-01-01");

            var input = "M:1 D:1 HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(10, count);
        }

        [Fact]
        public void FirstJanuary_Trough_FirstMay_For_10_Years_Returns_50_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2010-01-01");

            var input = "M:1-5 D:1 HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(50, count);
        }
    }
}
