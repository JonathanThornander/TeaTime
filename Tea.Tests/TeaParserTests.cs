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

            var input = "SHIFT(D:10-11 HH:18 SS:0, -10, M)";

            var tea = parser.Parse(input);

            var ocus = tea.GetBetween(reference, reference.AddMonths(10));
            foreach (var date in ocus)
            {
                Debug.WriteLine(date.ToString("F"));
            }
        }
    }
}
