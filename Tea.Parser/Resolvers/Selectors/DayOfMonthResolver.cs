﻿using System;
using System.Linq;
using Tea.Core.Expressions;
using Tea.Core.Expressions.Functional;
using Tea.Core.Expressions.Selectors;
using Tea.Parser.Utils;

namespace Tea.Parser.Resolvers.Selectors
{
    internal class DayOfMonthSelectorResolver : ExpressionResolver
    {
        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var parsedSelector = (ParsedSelector)parsedExpression;

            var days = RangeParser.ParseRange(parsedSelector.Parameter);

            if (days.Length == 1)
            {
                return new DayOfMonthSelector(days[0], parsedSelector.Negated);
            }

            var expressions = days.Select(day => new DayOfMonthSelector(day, parsedSelector.Negated)).ToArray();
            return new OrFunction(expressions);
        }

        public override bool ResolvesFor(ParsedExpression parsed)
        {
            return parsed.Name.Equals("D", StringComparison.CurrentCultureIgnoreCase);
        }

    }
}