using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TeaTime.Tests.Functions
{
    public class AndFunctionTests
    {
        [Fact]
        public void ANDFunction_Friday13th_Year_2000_1_Ocu()
        {
            TeaTimeParser parser = new TeaTimeParser();
            DateTime start = DateTime.Parse("2000-01-01");
            DateTime end = DateTime.Parse("2001-01-01");

            var input = "AND(W:Friday D:13) HH:0 MM:0 SS:0";

            // Act
            var tea = parser.Parse(input);
            var ocus = tea.GetBetween(start, end);
            var count = ocus.Count();

            // Assert
            Assert.Equal(1, count);
        }
    }
}
