using System;
using System.Linq;
using Tea.Parser.Resolvers.Selectors;

namespace Tea.Parser.Utils
{
    internal class RangeParser
    {
        internal int[] ParseRange(string parameter)
        {
            if (parameter.Contains('-'))
            {
                var startSring = parameter.Split('-')[0];
                var endString = parameter.Split('-')[1];

                var start = int.Parse(startSring);
                var end = int.Parse(endString);

                return GetRange(start, end);
            }
            else if (parameter.Contains('|'))
            {
                var startSring = parameter.Split('|')[0];
                var endString = parameter.Split('|')[1];

                var start = int.Parse(startSring);
                var end = int.Parse(endString);

                return new int[] { start, end };
            }

            var value = int.Parse(parameter);

            return new int[] { value };
        }

        internal int[] ParseRange(string parameter, INameToIntTranslator translator)
        {
            if (parameter.Contains('-'))
            {
                var startSring = parameter.Split('-')[0];
                var endString = parameter.Split('-')[1];

                var start = translator.NameToInt(startSring);
                var end = translator.NameToInt(endString);

                return GetRange(start, end);
            }
            else if (parameter.Contains('|'))
            {
                var startSring = parameter.Split('|')[0];
                var endString = parameter.Split('|')[1];

                var start = translator.NameToInt(startSring);
                var end = translator.NameToInt(endString);

                return new int[] { start, end };
            }

            var translated = translator.NameToInt(parameter);

            return new int[] { translated };
        }


        private static int[] GetRange(int start, int end)
        {
            if (start > end)
            {
                var temp = start;
                start = end;
                end = temp;
            }

            return Enumerable.Range(start, end - start + 1).ToArray();
        }
    }
}
