using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Parser.Utils
{
    internal class NamedDateTranslator
    {
        internal static int NameToInt(string name)
        {
            if (int.TryParse(name, out int value)) return value;

            switch (name.ToUpper())
            {
                case "SUNDAY":
                case "SUN":
                    return 0;
                case "MONDAY":
                case "MON":
                case "JAN":
                    return 1;
                case "TUESDAY":
                case "TUE":
                case "FEB":
                    return 2;
                case "WEDNESDAY":
                case "WED":
                case "MAR":
                    return 3;
                case "THURSDAY":
                case "THU":
                case "APR":
                    return 4;
                case "FRIDAY":
                case "FRI":
                case "MAY":
                    return 5;
                case "SATURDAY":
                case "SAT":
                case "JUN":
                    return 6;
                case "JUL":
                    return 7;
                case "AUG":
                    return 8;
                case "SEP":
                    return 9;
                case "OCT":
                    return 10;
                case "NOV":
                    return 11;
                case "DEC":
                    return 12;
                default:
                    throw new ArgumentException($"The name {name} does not translate to an integer");
            }
        }
    }
}
