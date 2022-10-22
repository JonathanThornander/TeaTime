using System.Diagnostics;
using TeaTime;

internal class Program
{
    private static void Main(string[] args)
    {
        TeaTimeParser schedule = new TeaTimeParser();
        DateTime reference = DateTime.Parse("2026-01-01");

        var input = "OR(M:Mars M:June M:September M:December) SHIFT(1W:Monday HH:15 MM:0 SS:0, -5, -5D)";

        var expression = schedule.Parse(input);

        var stopWatch = Stopwatch.StartNew();
        var next = expression.GetBetween(reference, reference.AddYears(10)).ToArray();
        stopWatch.Stop();

        foreach (var date in next)
        {
            Console.WriteLine(date.ToString("F"));
        }

        Console.WriteLine(next.Length);
        Console.WriteLine(stopWatch.ElapsedMilliseconds);
    }
}