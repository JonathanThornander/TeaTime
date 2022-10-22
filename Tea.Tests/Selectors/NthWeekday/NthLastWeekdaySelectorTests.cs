using Xunit;

namespace TeaTime.Tests.Selectors.NthWeekday
{
    public class NthLastWeekdaySelectorTests
    {
        [Fact]
        public void Last_1th_Saturday_WholeYear2024_Returns_4_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "-1W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(12, count);
        }

        [Fact]
        public void Last_2th_Saturday_WholeYear2024_Returns_4_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "-2W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(12, count);
        }

        [Fact]
        public void Last_3th_Saturday_WholeYear2024_Returns_4_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "-3W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(12, count);
            Assert.Contains(DateTime.Parse("2024-01-13"), ocus);
            Assert.Contains(DateTime.Parse("2024-02-10"), ocus);
            Assert.Contains(DateTime.Parse("2024-03-16"), ocus);
            Assert.Contains(DateTime.Parse("2024-04-13"), ocus);
            Assert.Contains(DateTime.Parse("2024-05-11"), ocus);
            Assert.Contains(DateTime.Parse("2024-06-15"), ocus);
            Assert.Contains(DateTime.Parse("2024-07-13"), ocus);
            Assert.Contains(DateTime.Parse("2024-08-17"), ocus);
            Assert.Contains(DateTime.Parse("2024-09-14"), ocus);
            Assert.Contains(DateTime.Parse("2024-10-12"), ocus);
            Assert.Contains(DateTime.Parse("2024-11-16"), ocus);
            Assert.Contains(DateTime.Parse("2024-12-14"), ocus);
        }

        [Fact]
        public void Last_4th_Saturday_WholeYear2024_Returns_12_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "-4W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(12, count);
        }

        /// <summary>
        /// Special case. Only 4 months of year 2024 have a fifth saturday
        /// </summary>
        [Fact]
        public void Last_5th_Saturday_WholeYear2024_Returns_4_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "-5W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(4, count);
            Assert.Contains(DateTime.Parse("2024-03-02"), ocus);
            Assert.Contains(DateTime.Parse("2024-06-01"), ocus);
            Assert.Contains(DateTime.Parse("2024-08-03"), ocus);
            Assert.Contains(DateTime.Parse("2024-11-02"), ocus);
        }

        [Fact]
        public void Negate_Last_1th_Saturday_WholeYear2024_Returns_4_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "!-1W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(366 - 12, count);
        }

        [Fact]
        public void Negate_Last_2th_Saturday_WholeYear2024_Returns_4_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "!-2W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(366 - 12, count);
        }

        [Fact]
        public void Negate_Last_3th_Saturday_WholeYear2024_Returns_4_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "!-3W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(366 - 12, count);
        }

        [Fact]
        public void Negate_Last_4th_Saturday_WholeYear2024_Returns_12_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "!-4W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(366 - 12, count);
        }

        /// <summary>
        /// Special case. Only 4 months of year 2024 have a fifth saturday
        /// </summary>
        [Fact]
        public void Negate_Last_5th_Saturday_WholeYear2024_Returns_4_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "!-5W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(366 - 4, count);
        }
    }
}
