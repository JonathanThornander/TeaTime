using System.Diagnostics;
using Tea.Core;
using Tea.Core.Expressions;
using Tea.Core.Expressions.Functional;
using Tea.Core.Expressions.Functional.Shifters;
using Tea.Core.Expressions.Selectors;
using Tea.Core.Expressions.Selectors.Modular;
using TeaTime;

internal class Program
{
    private static void Main(string[] args)
    {
        TeaTimeParser schedule = new TeaTimeParser();
        DateTime reference = DateTime.Parse("2022-01-01");

        while (true)
        {
            var input = Console.ReadLine();

            var expression = schedule.Parser(input);

            var stopWatch = Stopwatch.StartNew();
            var next = expression.GetBetween(reference, reference.AddYears(1));
            stopWatch.Stop();

            using var enumerator = next.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.ToString("F"));
            }

            Console.WriteLine(stopWatch.ElapsedMilliseconds);
        }

        
    }
}