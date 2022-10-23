using TeaTime;
using Xunit;

namespace Tea.Tests.CompleteFlow
{
    public class YearSelectorTests
    {
        [Fact]
        public void FirstJanuary_For_10_Years_But_Only_OneYear_Allowed_Returns_1_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2010-01-01");

            var input = "Y:2009 M:1 D:1 HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(1, count);
        }

        [Fact]
        public void FirstJanuary_For_10_Years_Excluding_OneYear_Returns_9_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2010-01-01");

            var input = "!Y:2005 M:1 D:1 HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(9, count);
        }

        [Fact]
        public void FirstJanuary_For_10_Years_Excluding_Range_Of_5_Years_Returns_5_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2010-01-01");

            var input = "!Y:2005-2010 M:1 D:1 HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(5, count);
        }

        [Fact]
        public void FirstJanuary_For_10_Years_Excluding_Two_Years_Returns_8_Ocus()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2010-01-01");

            var input = "!Y:2005|2007 M:1 D:1 HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(8, count);
        }
    }
}
