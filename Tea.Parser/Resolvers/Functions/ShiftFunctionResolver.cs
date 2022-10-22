using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tea.Core.Expressions;
using Tea.Core.Expressions.Functional;
using Tea.Core.Expressions.Functional.Shifters;
using Tea.Parser.Exceptions;
using Tea.Parser.Utils;

namespace Tea.Parser.Resolvers.Functions
{
    internal class ShiftFunctionResolver : ExpressionResolver
    {
        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var parsedFunction = (ParsedFunction)parsedExpression;

            if (parsedFunction.Parameters.Length != 3) throw new TeaParserException("SHIFT-function requires exactly 3 parameters");

            var expression = ParseExpressions(parsedFunction);
            var shiftValue = ParseShiftValue(parsedFunction);
            var shiftType = parsedFunction.Parameters[2].ToUpper();

            return shiftType switch
            {
                "Y" => new ShiftYearsFunction(expression, shiftValue),
                "M" => new ShiftMonthsFunction(expression, shiftValue),
                "D" => new ShiftDaysFunction(expression, shiftValue),
                "HH" => new ShiftHoursFunction(expression, shiftValue),
                "MM" => new ShiftMinutesFunction(expression, shiftValue),
                "SS" => new ShiftSecondsFunction(expression, shiftValue),

                _ => throw new TeaParserException($"Shift type {shiftType} is not supported"),
            };
        }

        private static int ParseShiftValue(ParsedFunction parsedFunction)
        {
            var shiftValueString = parsedFunction.Parameters[1];
            if (int.TryParse(shiftValueString, out int shiftValue) == false)
            {
                throw new TeaParserException($"Expected shift value but got '{shiftValueString}'");
            }
            return shiftValue;
        }

        private static AndFunction ParseExpressions(ParsedFunction parsedFunction)
        {
            var teaExpressionString = parsedFunction.Parameters[0];
            var expressionTokens = teaExpressionString.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var expressions = expressionTokens.Select(token => TeaParser.Instance.Parse(token)).ToArray();
            return new AndFunction(expressions);
        }
    }
}
