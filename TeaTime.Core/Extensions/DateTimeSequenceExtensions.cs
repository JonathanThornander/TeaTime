using System;
using System.Collections.Generic;

namespace TeaTime.Core.Extensions
{
    internal static class DateTimeExtensions
    {

        ///<summary>Gets the first week day following a date.</summary>
        ///<param name="date">The date.</param>
        ///<param name="dayOfWeek">The day of week to return.</param>
        ///<returns>The first dayOfWeek day following date, or date if it is on dayOfWeek.</returns>
        public static DateTime Next(this DateTime date, DayOfWeek dayOfWeek)
        {
            return date.AddDays((dayOfWeek < date.DayOfWeek ? 7 : 0) + dayOfWeek - date.DayOfWeek);
        }

        ///<summary>Gets the first week day following a date.</summary>
        ///<param name="date">The date.</param>
        ///<param name="dayOfWeek">The day of week to return.</param>
        ///<returns>The first dayOfWeek day following date, or date if it is on dayOfWeek.</returns>
        public static DateTime Previous(this DateTime date, DayOfWeek dayOfWeek)
        {
            return date.AddDays((dayOfWeek <= date.DayOfWeek ? 7 : 0) + dayOfWeek - date.DayOfWeek - 7);
        }

        public static TraverseResult Traverse(this IEnumerable<DateTime?> sequence)
        {
            using var enumerator = sequence.GetEnumerator();

            if (enumerator.MoveNext())
            {
                if (enumerator.Current is null)
                {
                    return new NullTraverseResult();
                }

                var min = (DateTime)enumerator.Current;
                var max = (DateTime)enumerator.Current;
                var allEqual = true;

                while (enumerator.MoveNext())
                {
                    if (enumerator.Current is null)
                    {
                        return new NullTraverseResult();
                    }

                    var current = (DateTime)enumerator.Current;

                    if (current > max)
                    {
                        max = current;
                        allEqual = false;
                    }
                    else if (current < min)
                    {
                        min = current;
                        allEqual = false;
                    }
                }

                if (allEqual)
                {
                    return new AllEqualTraverseResult { Value = max };
                }
                else
                {
                    return new UnequalResult() { Max = max, Min = min };
                }
            }

            throw new InvalidOperationException("Sequence contains no elements.");
        }

        public class TraverseResult
        {

        }

        public class UnequalResult : TraverseResult
        {
            public DateTime Max { get; set; }

            public DateTime Min { get; set; }
        }

        public class AllEqualTraverseResult : TraverseResult
        {
            public DateTime Value { get; set; }
        }

        public class NullTraverseResult : TraverseResult { }
    }
}
