﻿using System.Diagnostics;
using Tea.Core.Expressions;
using TeaTime;

internal class Program
{
    private static void Main(string[] args)
    {
        TeaTimeParser schedule = new TeaTimeParser();
        DateTime reference = DateTime.Parse("2020-01-01");

        var input = "OR(AND(W:Monday HH:10) AND()W:Wednesday HH:10)) MM";

        var couldParse = schedule.TryParse(out Expression expression, input);

        var stopWatch = Stopwatch.StartNew();
        var next = expression.GetBetween(reference, reference.AddDays(7)).ToArray();
        stopWatch.Stop();

        foreach (var date in next)
        {
            Console.WriteLine(date.ToString("F"));
        }

        Console.WriteLine(next.Length);
        Console.WriteLine(stopWatch.ElapsedMilliseconds);
    }
}