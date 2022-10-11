﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tea.Core.Expressions;
using Tea.Core.Expressions.Functional;
using Tea.Core.Expressions.Selectors;
using Tea.Parser.Utils;

namespace Tea.Parser.Resolvers.Selectors
{
    internal class MonthOfYearResolver : ExpressionResolver
    {
        public override Expression Resolve(ParsedExpression parsedExpression)
        {
            var parsedSelector = (ParsedSelector)parsedExpression;

            var days = new RangeParser().ParseRange(parsedSelector.Parameter);

            if (days.Length == 1)
            {
                return new MonthOfYearSelector(days[0], parsedSelector.Negated);
            }

            var expressions = days.Select(day => new MonthOfYearSelector(day, parsedSelector.Negated)).ToArray();

            return new OrFunction(expressions);
        }
    }
}
