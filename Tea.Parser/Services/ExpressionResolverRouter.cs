﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Tea.Core.Expressions.Selectors;
using Tea.Parser.Resolvers.Functions;
using Tea.Parser.Resolvers.Selectors;
using Tea.Parser.Utils;

namespace Tea.Parser.Services
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
                _ => throw new Exception(),
            };
        }

        private static ExpressionResolver GetFunctionResolver(ParsedFunction parsedFunction)
        {
            return parsedFunction.Name.ToUpperInvariant() switch
            {
                "OR" => new OrFunctionResolver(),
                "AND" => new AndFunctionResolver(),

                _ => throw new ArgumentException($"Could not find any resolver for function '{parsedFunction.Name}'"),
            };
        }

        private static ExpressionResolver GetSelectorResolver(ParsedSelector parsedSelector)
        {
            return parsedSelector.Name.ToUpperInvariant() switch
            {
                "M" => new MonthOfYearResolver(),
                "D" => new DayOfMonthSelectorResolver(),
                "W" => new DayOfWeekResolver(),
                "HH" => new HourOfDayResolver(),
                "MM" => new MinuteOfHourResolver(),
                "SS" => new SecondOfMinuteResolver(),

                _ => throw new ArgumentException($"Could not find any resolver for selector '{parsedSelector.Name}'"),
            };
        }

        private static ExpressionResolver GetConstnatResolver(ParsedConstant parsedConstant)
        {
            return parsedConstant.Name.ToUpperInvariant() switch
            {
                _ => throw new ArgumentException($"Could not find any resolver for constant '{parsedConstant.Name}'"),
            };
        }
    }
}
