using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TeaTime.Tests.Selectors
{
    public class SecondOfMinuteSelectorTests
    {
        [Fact]
        public void Second_10_for_one_minute_returns_1_ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01 00:00");
            DateTime end = DateTime.Parse("2000-01-01 00:01");

            var input = "SS:10";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(1, count);
        }

        [Fact]
        public void Second_10_through_12_for_one_minute_returns_3_ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01 00:00");
            DateTime end = DateTime.Parse("2000-01-01 00:01");

            var input = "SS:10-12";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(3, count);
        }


        [Fact]
        public void Second_10_and_12_for_one_minute_returns_2_ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01 00:00");
            DateTime end = DateTime.Parse("2000-01-01 00:01");

            var input = "SS:10|12";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(2, count);
        }

        [Fact]
        public void Every_second_excluding_second_10_for_one_minute_returns_59_ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01 00:00");
            DateTime end = DateTime.Parse("2000-01-01 00:01");

            var input = "!SS:10";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(59, count);
        }

        [Fact]
        public void Every_second_excluding_second_10_through_12_for_one_minute_returns_59_ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01 00:00");
            DateTime end = DateTime.Parse("2000-01-01 00:01");

            var input = "!SS:10-12";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(57, count);
        }

        [Fact]
        public void Every_second_excluding_second_10_and_12_for_one_minute_returns_59_ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01 00:00");
            DateTime end = DateTime.Parse("2000-01-01 00:01");

            var input = "!SS:10|12";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(58, count);
        }
    }
}
