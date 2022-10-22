using TeaTime;
using Xunit;

namespace Tea.Tests.CompleteFlow
{
    public class MinuteOfHourSelectorTests
    {
        [Fact]
        public void Every_hour_at_minute_10_for_one_day_returns_24_ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2000-01-02");

            var input = "MM:10 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(24, count);
        }

        [Fact]
        public void Every_hour_at_minute_10_through_12_for_one_day_returns_72_ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2000-01-02");

            var input = "MM:10-12 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(72, count);
        }

        [Fact]
        public void Every_hour_at_minute_10_an_12_for_one_day_returns_48_ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2000-01-02");

            var input = "MM:10|12 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(48, count);
        }

        [Fact]
        public void Every_minute_but_not_minute_10_for_one_hour_returns_59_ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01 00:00");
            DateTime end = DateTime.Parse("2000-01-01 01:00");

            var input = "!MM:10 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(59, count);
        }

        [Fact]
        public void Every_minute_but_not_minute_10_trough_12_for_one_hour_returns_57_ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01 00:00");
            DateTime end = DateTime.Parse("2000-01-01 01:00");

            var input = "!MM:10-12 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(57, count);
        }

        [Fact]
        public void Every_minute_but_not_minute_10_and_12_for_one_hour_returns_58_ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01 00:00");
            DateTime end = DateTime.Parse("2000-01-01 01:00");

            var input = "!MM:10|12 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(58, count);
        }
    }
}
