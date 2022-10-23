﻿using System;
using System.Linq;
using Tea.Core.Expressions;
using Tea.Core.Expressions.Functional;
using Tea.Core.Expressions.Selectors.NthWeekday;
using Tea.Parser.Exceptions;
using Tea.Parser.Utils;

namespace Tea.Parser.Resolvers.Selectors.NthWeekday
{
    internal class NthNextWeekdayResolver : ExpressionResolver
    {
        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var parsedSelector = (ParsedSelector)parsedExpression;

            var nthValueString = parsedSelector.Name.ToUpper().Split("W")[0];

            if (int.TryParse(nthValueString, out int nthValue) == false)
            {
                throw new TeaParserException($"Expected nth-value but got '{nthValueString}'");
            }

            var days = new RangeParser().ParseRange(parsedSelector.Parameter, new WeekDayTranslator())
               .Select(day => ((DayOfWeek)day))
               .ToArray();

            if (days.Length == 1)
            {
                return new NthNextWeekdaySelector(nthValue, days[0], parsedSelector.Negated);
            }

            var expressions = days.Select(day => new NthNextWeekdaySelector(1, day, parsedSelector.Negated)).ToArray();

            if (parsedSelector.Negated)
            {
                return new AndFunction(expressions);
            }

            return new OrFunction(expressions);
        }
    }
}