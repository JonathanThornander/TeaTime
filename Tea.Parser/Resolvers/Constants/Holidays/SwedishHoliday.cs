using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tea.Core.Expressions;
using Tea.Parser.Utils;

namespace Tea.Parser.Resolvers.Constants.Holidays
{
    internal class SwedishHolidayConstantResolver : ExpressionResolver
    {
        private readonly string[] holidays = new string[]
        {
            "M:1 D:1", // Nyårsdagen
            "M:1 D:13", // Trettondagen
            "SHIFT(EASTER:Catholic, -2, D)", // Långfredag
            "SHIFT(EASTER:Catholic, -1, D)", // Påskafton
            "EASTER:Catholic", // Påskdagen
            "SHIFT(EASTER:Catholic, 1, D)", // Annandag Påsk
            "M:5 D:1", // Första maj
            "SHIFT(EASTER:Catholic, 39, D)", // Kristi himmelfärd
            "SHIFT(EASTER:Catholic, 49, D)", // PingstAfton
            "SHIFT(EASTER:Catholic, 50, D)", // Pingst
            "M:6 D:6", // Nationaldagen
            "M:6 W:Saturday D:20-26", // Midsommarafton
            "SHIFT(M:June W:Saturday D:20-26, 1, D)", // Midsommardagen
            "OR(AND(M:10 D:31) AND(M:11 D:1-6)) W:Saturday", // Alla helgona
            "M:12 D:24", // Julafton
            "M:12 D:25", // Juldagen
            "M:12 D:26", // Annandag jul
            "M:12 D:31", // Nyårsafton
        };

        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var andFunctions = holidays.Select(holiday => $"AND({holiday})");
            var arguments = string.Join(" ", andFunctions);
            var expression = $"OR({arguments})";

            return TeaParser.Instance.Parse(expression);
        }
    }
}
