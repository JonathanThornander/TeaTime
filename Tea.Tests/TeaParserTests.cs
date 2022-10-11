using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Parser;
using Xunit;

namespace Tea.Tests
{
    public class TeaParserTests
    {
        [Fact]
        public void Test1()
        {
            var parser = TeaParser.Instance;
            var reference = DateTime.Parse("2022-10-11");

            var input = "AND(!W:FRIDAY HH:0 MM:0 SS:0)";

            var tea = parser.Parse(input);

            var ocus = tea.GetBetween(reference, reference.AddYears(1));
            foreach (var date in ocus)
            {
                Debug.WriteLine(date.ToString("F"));
            }
        }
    }
}
