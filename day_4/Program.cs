using System;
using System.Text.RegularExpressions;

namespace day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var formattedData = FormatData("assets/input.txt");
            int validPassports = Passports.CountValidPassportsQ2(formattedData);
            Console.WriteLine("There are {0} valid passports.", validPassports);

        }
        static string[] FormatData(string datapath)
        {
            return System.IO.File.ReadAllText(datapath).Split(
                new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries
            );
        }
    }
    class Passports
    {
        public static int CountValidPassportsQ1(string[] passportArray)
        {
            int count = 0;
            foreach (string passport in passportArray)
            {
                string formattedPassport = passport.Replace(System.Environment.NewLine, " ");

                string pattern = @"^(?=.*\becl\b)(?=.*\bpid\b)(?=.*\beyr\b)(?=.*\bhcl\b)(?=.*\bbyr\b)(?=.*\biyr\b)(?=.*\bhgt\b).*$";

                if (Regex.IsMatch(formattedPassport, pattern))
                {
                    count++;
                }
            }
            return count;
        }

        public static int CountValidPassportsQ2(string[] passportArray)
        {
            int count = 0;
            foreach (string passport in passportArray)
            {
                string formattedPassport = passport.Replace(System.Environment.NewLine, " ");

                string pattern = @"^(?=.*\becl\b:(amb|blu|brn|gry|grn|hzl|oth)($|\s))(?=.*\bpid\b:\d{9}($|\s))(?=.*\beyr\b:20((2[0-9])|(30))($|\s))(?=.*\bhcl\b:#[0-9A-Fa-f]{6}($|\s))(?=.*\bbyr\b:(19[2-9][0-9]|200[0-2])($|\s))(?=.*\biyr\b:20(1[0-9]|20)($|\s))(?=.*\bhgt\b:((1([5-8][0-9]|(9[0-3]))cm)|((59|6[0-9]|7[0-6])in))($|\s)).*$";

                if (Regex.IsMatch(formattedPassport, pattern))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
