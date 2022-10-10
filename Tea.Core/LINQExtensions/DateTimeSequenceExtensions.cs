using System;
using System.Collections.Generic;

namespace Tea.Core.LINQExtensions
{
    public static class DateTimeSequenceExtensions
    {

        public static TraverseResult Traverse(this IEnumerable<DateTime?> sequence)
        {
            using var enumerator = sequence.GetEnumerator();

            if (enumerator.MoveNext())
            {
                if (enumerator.Current is null)
                {
                    return new NullTraverseResult();
                }

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
                    else if (current < max)
                    {
                        allEqual = false;
                    }
                }

                if (allEqual)
                {
                    return new AllEqualTraverseResult { Value = max };
                }
                else
                {
                    return new UnequalResult() { Max = max };
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
        }

        public class AllEqualTraverseResult : TraverseResult
        {
            public DateTime Value { get; set; }
        }

        public class NullTraverseResult : TraverseResult { }
    }
}
