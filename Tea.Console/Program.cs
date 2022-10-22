using System.Diagnostics;
using TeaTime;

internal class Program
{
    private static void Main(string[] args)
    {
        TeaTimeParser schedule = new TeaTimeParser();
        DateTime reference = DateTime.Parse("2020-01-01");

        var input = "SWEHOL HH:00 MM:0 SS:0";

        var expression = schedule.Parse(input);

        var stopWatch = Stopwatch.StartNew();
        var next = expression.GetBetween(reference, reference.AddYears(1)).ToArray();
        stopWatch.Stop();

        foreach (var date in next)
        {
            Console.WriteLine(date.ToString("F"));
        }

        Console.WriteLine(next.Length);
        Console.WriteLine(stopWatch.ElapsedMilliseconds);
    }
}