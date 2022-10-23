using Xunit;

namespace TeaTime.Tests.Selectors.NthWeekday
{
    public class NthNextWeekdaySelectorTests
    {
        [Fact]
        public void Next_1th_Saturday_WholeYear2024_Returns_4_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "1W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(12, count);
        }

        [Fact]
        public void Next_2th_Saturday_WholeYear2024_Returns_4_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "2W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(12, count);
        }

        [Fact]
        public void Next_3th_Saturday_WholeYear2024_Returns_4_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "3W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(12, count);
            Assert.Contains(DateTime.Parse("2024-01-20"), ocus);
            Assert.Contains(DateTime.Parse("2024-02-17"), ocus);
            Assert.Contains(DateTime.Parse("2024-03-16"), ocus);
            Assert.Contains(DateTime.Parse("2024-04-20"), ocus);
            Assert.Contains(DateTime.Parse("2024-05-18"), ocus);
            Assert.Contains(DateTime.Parse("2024-06-15"), ocus);
            Assert.Contains(DateTime.Parse("2024-07-20"), ocus);
            Assert.Contains(DateTime.Parse("2024-08-17"), ocus);
            Assert.Contains(DateTime.Parse("2024-09-21"), ocus);
            Assert.Contains(DateTime.Parse("2024-10-19"), ocus);
            Assert.Contains(DateTime.Parse("2024-11-16"), ocus);
            Assert.Contains(DateTime.Parse("2024-12-21"), ocus);
        }

        [Fact]
        public void Next_4th_Saturday_WholeYear2024_Returns_12_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "4W:Saturday HH:0 MM:0 SS:0";

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
        public void Next_5th_Saturday_WholeYear2024_Returns_4_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "5W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(4, count);
            Assert.Contains(DateTime.Parse("2024-03-30"), ocus);
            Assert.Contains(DateTime.Parse("2024-06-29"), ocus);
            Assert.Contains(DateTime.Parse("2024-08-31"), ocus);
            Assert.Contains(DateTime.Parse("2024-11-30"), ocus);
        }

        [Fact]
        public void Negate_Next_1th_Saturday_WholeYear2024_Returns_4_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "!1W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(366 - 12, count);
        }

        [Fact]
        public void Negate_Next_2th_Saturday_WholeYear2024_Returns_4_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "!2W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(366 - 12, count);
        }

        [Fact]
        public void Negate_Next_3th_Saturday_WholeYear2024_Returns_4_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "!3W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(366 - 12, count);
        }

        [Fact]
        public void Negate_Next_4th_Saturday_WholeYear2024_Returns_12_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "!4W:Saturday HH:0 MM:0 SS:0";

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
        public void Negate_Next_5th_Saturday_WholeYear2024_Returns_4_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2024-01-01");
            DateTime end = DateTime.Parse("2025-01-01");

            var input = "!5W:Saturday HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(366 - 4, count);
        }
    }
}
