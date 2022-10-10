using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Parser.Utils;
using Xunit;

namespace Tea.Tests.Utils
{
    public class NamedDateTranslatorTests
    {
        [Fact]
        public void Translate_Jan_Returns_1()
        {
            var translated = NamedDateTranslator.NameToInt("JAN");
            Assert.Equal(1, translated);
        }
    }
}
