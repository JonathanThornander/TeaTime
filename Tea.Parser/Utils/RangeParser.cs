using System;
using System.Linq;

namespace Tea.Parser.Utils
{
    internal class RangeParser
    {
        internal static int[] ParseRange(string parameter, bool translate = false)
        {
            if (parameter.Contains('-'))
            {
                var startSring = parameter.Split('-')[0];
                var endString = parameter.Split('-')[1];

                int start, end;

                if (translate)
                {
                    start = NamedDateTranslator.NameToInt(startSring);
                    end = NamedDateTranslator.NameToInt(endString);
                }
                else
                {
                    start = int.Parse(startSring);
                    end = int.Parse(endString);
                }

                if (start > end)
                {
                    var temp = start;
                    start = end;
                    end = temp;
                }

                return Enumerable.Range(start, end-start+1).ToArray();
            }
            else if (parameter.Contains('|'))
            {
                throw new NotImplementedException("Not yet implemented");
            }
            else
            {
                var value = int.Parse(parameter);

                return new int[] { value };
            }
        }
    }
}
