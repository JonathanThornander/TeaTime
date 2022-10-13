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
        DateTime reference = DateTime.Parse("1998-01-01");

        var input = "!Y%:4 M:1 D:1 HH:0 MM:0 SS:0";

        var expression = schedule.Parse(input);

        var stopWatch = Stopwatch.StartNew();
        var next = expression.GetBetween(reference, reference.AddYears(100)).ToArray();
        stopWatch.Stop();

        foreach (var date in next)
        {
            Console.WriteLine(date.ToString("F"));
        }

        Console.WriteLine(stopWatch.ElapsedMilliseconds);


    }
}