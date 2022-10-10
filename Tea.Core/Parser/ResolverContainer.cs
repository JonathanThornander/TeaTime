using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Core.Parser.Resolvers.Functions;
using Tea.Core.Parser.Resolvers.Selectors;

namespace Tea.Core.Parser
{
    public class Container
    {
        private static readonly ExpressionResolver[] _resolvers;
        private static readonly TeaParser _teaParser;

        static Container()
        {
            _teaParser = new TeaParser();
            _resolvers = new ExpressionResolver[]
            {
                new AllFunctionResolver(),

                new DayOfMonthSelectorResolver()
            };
        }

        public static IEnumerable<ExpressionResolver> Resolvers { get => _resolvers; }

        public static TeaParser Parser { get => _teaParser; }


    }
}
