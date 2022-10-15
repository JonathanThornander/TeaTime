using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Parser;
using TeaTime;
using Xunit;

namespace Tea.Tests.CompleteFlow
{
    public class DayOfMonthSelectorTests
    {
        [Fact]
        public void FirstDayOfMonth_WholeYear_Returns_12_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2001-01-01");

            var input = "D:1 HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(12, count);
        }

        [Fact]
        public void First_Or_Seccond_DayOfMonth_WholeYear_Returns_24_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2001-01-01");

            var input = "D:1|2 HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(24, count);
        }

        [Fact]
        public void First_Through_10th_DayOfMonth_WholeYear_Returns_120_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2001-01-01");

            var input = "D:1-10 HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(120, count);
        }
    }
}
