using TeaTime;
using Xunit;

namespace Tea.Tests.CompleteFlow
{
    public class HourOfDaySelectorTests
    {
        [Fact]
        public void Everyday_at_12_for_one_week_returns_7_ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2000-01-08");

            var input = "HH:12 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(7, count);
        }

        [Fact]
        public void Everyday_at_12_and_18_for_one_week_returns_7_ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2000-01-08");

            var input = "HH:12|18 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(14, count);
        }

        [Fact]
        public void Every_hour_except_1_for_one_day_returns_23_ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2000-01-02");

            var input = "!HH:12 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(23, count);
        }

        [Fact]
        public void Every_hour_except_range_of_4_hours_for_one_day_returns_20_ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2000-01-02");

            var input = "!HH:12-15 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(20, count);
        }

        [Fact]
        public void Every_hour_except_2_hours_for_one_day_returns_22_ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2000-01-02");

            var input = "!HH:12|15 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(22, count);
        }
    }
}
