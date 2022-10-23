# TeaTime 🍵

TeaTime is a .NET library for creating advanced patterns of reccuring events using simple syntax. Its purpose is to offer what other tools like Cron cannot. Unlike related tools like Cron which is designed for low level scheduling like regulary running computer tasks, TeaTime is also designed to be used in real life scenarios: 
## Example of use casees

### Scheduling opening hours
The following TeaExpression yields at 8AM during weekdays (mon-fri) and 10AM during weekends (sat-sun).
```
OR(AND(WEEKDAY HH:08) AND(WEEKEND HH:10)) HH
```

### Scheduling holidays
The following TeaExpression yields at midnight during every 25th of december.
```
M:12 D:25 D
```

The following TeaExpression yields 30 days after orthodox easter
```
SHIFT(EASTER:Orthodox, 30, D) D
```

### Scheduling payday
The following TeaExpression yields the 25th every month if it is a weekday, otherwise the last friday
```
OR(AND(WEEKDAY D:25) AND(W:Friday D:24) AND(W:Friday D:23)) D
```

## Syntax
There are three different syntax groups that can be used to express TeaTime-expressions:
* Selectors
* Functions
* Constants

### Selectors
Selectors is used to express a single rule for occuring events. Selectors concists of a name and a value and is expressed '{selector}:{value}'.

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
| Function | Name  | Annotation | Example                   | Example meening                      |
|----------|-------|------------|---------------------------|--------------------------------------|
| OR       | Or    |            | OR(D:15 D:25)             | Either day 15 or day 25 of the month |
| AND      | And   |            | AND(D:13 W:Friday)        | The 13th, but only when it's friday  |
| SHIFT    | Shift |            | SHIFT(M:12 D:25 D, -6, M) | 6 months before 25th of december     |

### Constants
Constants are pre-made expressions. Like any other expression, they can be nested inside of other expressions. Constants serves two purposes:
1. Reduces the length of the expression
2. Reduces the need of writing complex expressions like easter (dependent on the moon-phase)
| Constant | Name         | Annotation | Constant meening                           |
|----------|--------------|------------|--------------------------------------------|
| WEEKDAY  | Weekday      |            | Yields monday through friday               |
| WEEKEND  | Weekend      |            | Yields saturdays and sundays               |
| Y        | Whoe year    |            | Yields january 1st every year at midnight  |
| M        | Whole month  |            | Yields the first every month at midnight   |
| D        | Whole day    |            | Yields midnight                            |
| HH       | Whole hour   |            | Yields every hour at minute 0 and second 0 |
| MM       | Whole minute |            | Yields every minute at second 0            |
| LEAPYEAR | Leap year    |            | Yields every second during leapyears       |
