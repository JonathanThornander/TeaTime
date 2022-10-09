using System.Diagnostics;
using Tea.Core;
using Tea.Core.Expressions;
using Tea.Core.Expressions.Functional;
using Tea.Core.Expressions.Functional.Shifters;
using Tea.Core.Expressions.Selectors;
using Tea.Core.Expressions.Selectors.Modular;

internal class Program
{
    private static void Main(string[] args)
    {


        var mainExpression = new AndFunction(new Expression[]
        {
            new OrFunction(new Expression[]
            {
                new AndFunction(new Expression[]
                {
                    new DayOfMonthSelector(25),
                    new DayOfWeekSelector(DayOfWeek.Saturday, true),
                    new DayOfWeekSelector(DayOfWeek.Sunday, true),
                }),
                new AndFunction(new Expression[]
                {
                    new OrFunction(new Expression[]
                    {
                        new DayOfMonthSelector(23),
                        new DayOfMonthSelector(24)
                    }),
                    new DayOfWeekSelector(DayOfWeek.Friday)
                }),
            }),
            new HourOfDaySelector(0),
            new MinuteOfHourSelector(0),
            new SecondOfMinuteSelector(0)
        });

        DateTime reference = DateTime.Parse("2022-01-01");


        var stopWatch = Stopwatch.StartNew();
        var next = mainExpression.GetBetween(reference, reference.AddYears(10)).ToArray();
        stopWatch.Stop();

        foreach (var date in next)
        {
            Console.WriteLine(date.ToString("F"));
        }

        Console.WriteLine(stopWatch.ElapsedMilliseconds);
    }
}