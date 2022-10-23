using Tea.Parser.Exceptions;
using Tea.Parser.Resolvers.Constants;
using Tea.Parser.Resolvers.Functions;
using Tea.Parser.Resolvers.Selectors;
using Tea.Parser.Resolvers.Selectors.Modular;
using Tea.Parser.Resolvers.Selectors.NthWeekday;
using Tea.Parser.Utils;
using TeaTime.Parser.Resolvers.Constants;

namespace Tea.Parser
{
    internal class ExpressionResolverRouter
    {
        internal ExpressionResolver GetResolver(ParsedExpression parsedExpression)
        {
            return parsedExpression switch
            {
                ParsedSelector parsedSelector => GetSelectorResolver(parsedSelector),
                ParsedFunction parsedFunction => GetFunctionResolver(parsedFunction),
                ParsedConstant parsedConstant => GetConstnatResolver(parsedConstant),

                _ => throw new TeaParserException(),
            };
        }

        private static ExpressionResolver GetFunctionResolver(ParsedFunction parsedFunction)
        {
            return parsedFunction.Name.ToUpperInvariant() switch
            {
                "OR" => new OrFunctionResolver(),
                "AND" => new AndFunctionResolver(),
                "SHIFT" => new ShiftFunctionResolver(),

                _ => throw new TeaParserException($"Could not find any resolver for function '{parsedFunction.Name}'"),
            };
        }

        private static ExpressionResolver GetSelectorResolver(ParsedSelector parsedSelector)
        {
            return parsedSelector.Name.ToUpperInvariant() switch
            {
                "Y" => new YearResolver(),
                "M" => new MonthOfYearResolver(),
                "D" => new DayOfMonthSelectorResolver(),
                "W" => new DayOfWeekResolver(),
                "HH" => new HourOfDayResolver(),
                "MM" => new MinuteOfHourResolver(),
                "SS" => new SecondOfMinuteResolver(),

                "Y%" => new YearModResolver(),
                "M%" => new MonthModResolver(),
                "D%" => new DayModResolver(),
                "HH%" => new HourModResolver(),
                "MM%" => new MinuteModResolver(),
                "SS%" => new SecondModResolver(),

                "-5W" => new NthLastWeekdayResolver(),
                "-4W" => new NthLastWeekdayResolver(),
                "-3W" => new NthLastWeekdayResolver(),
                "-2W" => new NthLastWeekdayResolver(),
                "-1W" => new NthLastWeekdayResolver(),

                "1W" => new NthNextWeekdayResolver(),
                "2W" => new NthNextWeekdayResolver(),
                "3W" => new NthNextWeekdayResolver(),
                "4W" => new NthNextWeekdayResolver(),
                "5W" => new NthNextWeekdayResolver(),

                "EASTER" => new EasterResolver(),

                _ => throw new TeaParserException($"Could not find any resolver for selector '{parsedSelector.Name}'"),
            };
        }

        private static ExpressionResolver GetConstnatResolver(ParsedConstant parsedConstant)
        {
            return parsedConstant.Name.ToUpperInvariant() switch
            {
                "LEAPYEAR" => new LeapYearConstantResolver(),

                "MIDNIGHT" => new MidnightConstantResolver(),
                "NOON" => new NoonConstantResolver(),

                "WEEKDAY" => new WeekdayConstantResolver(),
                "WEEKEND" => new WeekendConstantResolver(),

                "Y" => new YearlyConstantResolver(),
                "M" => new MonthlyConstantResolver(),
                "D" => new DailyConstantResolver(),
                "HH" => new HourlyConstantResolver(),
                "MM" => new MinutelyConstantResolver(),

                _ => throw new TeaParserException($"Could not find any resolver for constant '{parsedConstant.Name}'"),
            };
        }
    }
}
