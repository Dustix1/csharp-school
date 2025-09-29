using System.Globalization;

namespace cv3
{
    enum ParseIntOption
    {
        NONE = 1,
        ALLOW_WHITESPACES = 2,
        ALLOW_NEGATIVE_NUMBERS = 4,
        IGNORE_INVALID_CHARACTERS = 6
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Výsledek: " + ParseInt(input));

            Console.Write("Výsledek or null: ");
            int? orNullNum = ParseIntOrNull(input);
            if (orNullNum != null)
            {
                Console.WriteLine(orNullNum);
            } else
            {
                Console.WriteLine("not parseable");
            }

                Console.Write("Výsledek tryParse: ");
            if (TryParseInt(input, out int tryParseIntNum) == true)
            {
                Console.WriteLine(tryParseIntNum);
            } else
            {
                Console.WriteLine("not parseable");
            }

            Console.Write("Výsledek tryParseOption: ");
            ParseIntOption options = ParseIntOption.ALLOW_WHITESPACES | ParseIntOption.IGNORE_INVALID_CHARACTERS | ParseIntOption.ALLOW_NEGATIVE_NUMBERS;
            if (TryParseIntWithOption(input, out int tryParseIntOptionNum, options) == true)
            {
                Console.WriteLine(tryParseIntOptionNum);
            }
            else
            {
                Console.WriteLine("not parseable");
            }


            //CultureInfo ciCz = CultureInfo.GetCultureInfo("CS-cz");
            //CultureInfo ciUs = CultureInfo.GetCultureInfo("en-US");
            //double n = double.Parse(input, ciUs);
        }

        static int ParseInt(string s)
        {
            int currNum;
            int convertedNum = 0;
            foreach (char c in s)
            {
                if (c >= '0' && c <= '9')
                {
                    currNum = c - '0';
                    convertedNum = convertedNum * 10 + currNum;
                } else
                {
                    return -1;
                }
            }
            return convertedNum;
        }

        static int? ParseIntOrNull(string s)
        {
            int currNum;
            int convertedNum = 0;
            foreach (char c in s)
            {
                if (c >= '0' && c <= '9')
                {
                    currNum = c - '0';
                    convertedNum = convertedNum * 10 + currNum;
                }
                else
                {
                    return null;
                }
            }
            return convertedNum;
        }

        static bool TryParseInt(string s, out int result)
        {
            int currNum;
            int convertedNum = 0;
            foreach (char c in s)
            {
                if (c >= '0' && c <= '9')
                {
                    currNum = c - '0';
                    convertedNum = convertedNum * 10 + currNum;
                }
                else
                {
                    result = convertedNum;
                    return false;
                }
            }
            result = convertedNum;
            return true;
        }

        static bool TryParseIntWithOption(string s, out int result, ParseIntOption options)
        {
            int currNum;
            int convertedNum = 0;
            foreach (char c in s)
            {
                if (c >= '0' && c <= '9')
                {
                    currNum = c - '0';
                    convertedNum = convertedNum * 10 + currNum;
                }
                else
                {
                    if (options.HasFlag(ParseIntOption.IGNORE_INVALID_CHARACTERS)) continue;
                    if (options.HasFlag(ParseIntOption.ALLOW_WHITESPACES) && c == ' ') continue;
                    result = convertedNum;
                    return false;
                }
            }
            if (s[0] == '-' && options.HasFlag(ParseIntOption.ALLOW_NEGATIVE_NUMBERS)) convertedNum *= -1;
            result = convertedNum;
            return true;
        }
    }
}
