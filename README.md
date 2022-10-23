# TeaTime 🍵

TeaTime is a .NET library for creating advanced patterns of recurring events using simple and human readable syntax. Its purpose is to offer what other tools like Cron cannot. Unlike related tools like Cron which is designed for low level scheduling i.g regularly running computer tasks, TeaTime is also designed to be used in real life scenarios.

## Examples

### Scheduling opening hours
The following TeaExpression yields at 8AM during weekdays (mon-fri) and 10AM during weekends (sat-sun).

```CSHARP
using TeaTime;

var tea = "OR(AND(WEEKDAY HH:08) AND(WEEKEND HH:10)) HH";

var parser = new TeaTimeParser();
var expression = parser.Parse(tea);

foreach (var date in expression.GetBetween(DateTime.Parse("2000-01-01"), DateTime.Parse("2000-01-08")))
{
    Console.WriteLine(date.ToString("F"));
}
```
Outputs:
```
Saturday, 1 January 2000 10:00:00
Sunday, 2 January 2000 10:00:00
Monday, 3 January 2000 08:00:00
Tuesday, 4 January 2000 08:00:00
Wednesday, 5 January 2000 08:00:00
Thursday, 6 January 2000 08:00:00
Friday, 7 January 2000 08:00:00
```

### Scheduling holidays
The following TeaExpression yields every second full hour during every 25th of december.

```CSHARP
using TeaTime;

var tea = "M:12 D:25 HH%:2 HH";

var parser = new TeaTimeParser();
var expression = parser.Parse(tea);

foreach (var date in expression.GetBetween(DateTime.Parse("2000-01-01"), DateTime.Parse("2001-01-01")))
{
    Console.WriteLine(date.ToString("F"));
}
```
Outputs:
```
Monday, 25 December 2000 00:00:00
Monday, 25 December 2000 02:00:00
Monday, 25 December 2000 04:00:00
Monday, 25 December 2000 06:00:00
Monday, 25 December 2000 08:00:00
Monday, 25 December 2000 10:00:00
Monday, 25 December 2000 12:00:00
Monday, 25 December 2000 14:00:00
Monday, 25 December 2000 16:00:00
Monday, 25 December 2000 18:00:00
Monday, 25 December 2000 20:00:00
Monday, 25 December 2000 22:00:00
```

### Scheduling relative dates
The following example yields 30 days after orthodox easter at midnight every year

```CSHARP
using TeaTime;

var tea = "SHIFT(EASTER:Orthodox, 30, D) D";

var parser = new TeaTimeParser();
var expression = parser.Parse(tea);

foreach (var date in expression.GetBetween(DateTime.Parse("2000-01-01"), DateTime.Parse("2010-01-01")))
{
    Console.WriteLine(date.ToString("F"));
}
```
Outputs:
```
Tuesday, 30 May 2000 00:00:00
Tuesday, 15 May 2001 00:00:00
Tuesday, 4 June 2002 00:00:00
Tuesday, 27 May 2003 00:00:00
Tuesday, 11 May 2004 00:00:00
Tuesday, 31 May 2005 00:00:00
Tuesday, 23 May 2006 00:00:00
Tuesday, 8 May 2007 00:00:00
Tuesday, 27 May 2008 00:00:00
Tuesday, 19 May 2009 00:00:00
```

### Scheduling payday
The following example yields the 25th every month, or the friday before if the 25th occurs on a weekend (Normal swedish payday).

```CSHARP
using TeaTime;

var tea = "OR(AND(WEEKDAY D:25) AND(W:Friday D:23-24)) D";

var parser = new TeaTimeParser();
var expression = parser.Parse(tea);

foreach (var date in expression.GetBetween(DateTime.Parse("2000-01-01"), DateTime.Parse("2001-01-01")))
{
    Console.WriteLine(date.ToString("F"));
}
```
Outputs:
```
Tuesday, 25 January 2000 00:00:00
Friday, 25 February 2000 00:00:00
Friday, 24 March 2000 00:00:00
Tuesday, 25 April 2000 00:00:00
Thursday, 25 May 2000 00:00:00
Friday, 23 June 2000 00:00:00
Tuesday, 25 July 2000 00:00:00
Friday, 25 August 2000 00:00:00
Monday, 25 September 2000 00:00:00
Wednesday, 25 October 2000 00:00:00
Friday, 24 November 2000 00:00:00
Monday, 25 December 2000 00:00:00
```

## Syntax
There are three different syntax groups that can be used to express TeaTime-expressions:
* Selectors
* Functions
* Constants

### Selectors
Selectors are the fundamentals of an TeaTime expression. They are used to express single rules for occuring events. Selectors concists of a name and a value and is expressed '{selector}:{value}'.

| Selector | Name             | Annotation                                    | Example | Example meening            |
|----------|------------------|-----------------------------------------------|---------|----------------------------|
| Y        | Year             |                                               | Y:2000  | The year 2000              |
| M        | Month of year    | Can also contain named values like 'M:April'  | M:4     | April                      |
| D        | Day of month     |                                               | D:17    | The 17'th day of the month |
| W        | Day of week      | Can also contain named values like 'W:Friday' | W:1     | Sunday                     |
| HH       | Hour of day      |                                               | HH:10   | 10 AM                      |
| MM       | Minute of hour   |                                               | MM:15   | Minute 15 every hour       |
| SS       | Second of minute |                                               | SS:59   | Second 59 every minute     |

### Functions
Functions transforms an expression using rules. A function conciscts of a name and one or more parameter depending on the type of the function. 
| Function | Name  | Example                   | Example meening                      |
|----------|-------|---------------------------|--------------------------------------|
| OR       | Or    | OR(D:15 D:25)             | Either day 15 or day 25 of the month |
| AND      | And   | AND(D:13 W:Friday)        | The 13th, but only when it's friday  |
| SHIFT    | Shift | SHIFT(M:12 D:25 D, -6, M) | 6 months before 25th of december     |

### Constants
Constants are pre-made expressions. Like any other expression, they can be nested inside of other expressions. Constants serves two purposes:

1. Reduces the length of the expression
2. Reduces the need of writing complex expressions

| Constant | Name         | Constant meening                           |
|----------|--------------|--------------------------------------------|
| WEEKDAY  | Weekday      | Yields monday through friday               |
| WEEKEND  | Weekend      | Yields saturdays and sundays               |
| Y        | Whoe year    | Yields january 1st every year at midnight  |
| M        | Whole month  | Yields the first every month at midnight   |
| D        | Whole day    | Yields midnight                            |
| HH       | Whole hour   | Yields every hour at minute 0 and second 0 |
| MM       | Whole minute | Yields every minute at second 0            |
| LEAPYEAR | Leap year    | Yields every second during leapyears       |
