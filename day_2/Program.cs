using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace day_2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<String> rawdata = PassDataToList("assets/input.txt");

            List<PasswordWithRule> formattedlist = FormatList(rawdata);

            HandleQuestionOne(formattedlist);
            HandleQuestionTwo(formattedlist);
        }

        static void HandleQuestionOne(List<PasswordWithRule> list)
        {
            int passedCount = 0;
            foreach (PasswordWithRule item in list)
            {
                int min = Convert.ToInt32(item.rule.Split("-")[0].Trim());
                int max = Convert.ToInt32(item.rule.Split("-")[1].Trim());
                int matchesCount = Regex.Matches(item.password, item.letter).Count;

                if (matchesCount >= min && matchesCount <= max)
                {
                    passedCount++;
                }
            }
            Console.WriteLine("{0} Passwords are valid on part one.", passedCount);
        }
        static void HandleQuestionTwo(List<PasswordWithRule> list)
        {
            int passedCount = 0;

            foreach (PasswordWithRule item in list)
            {
                var i = Convert.ToInt32(item.rule.Split("-")[0].Trim());
                var j = Convert.ToInt32(item.rule.Split("-")[1].Trim()) - Convert.ToInt32(i);
                i--;
                j--;
                Regex regex = new Regex($"(^.{{{i}}}[{item.letter}].{{{j}}}[^{item.letter}])|(^.{{{i}}}[^{item.letter}].{{{j}}}[{item.letter}])");

                Match match = regex.Match(item.password);

                if (match.Success)
                {
                    passedCount++;
                }
            }
            Console.WriteLine("{0} Passwords are valid on part two.", passedCount);
        }
        static List<PasswordWithRule> FormatList(List<String> List)
        {
            List<PasswordWithRule> formattedlist = new List<PasswordWithRule>();
            foreach (string line in List)
            {
                var passwordwithrule = new PasswordWithRule();
                passwordwithrule.rule = line.Split(':')[0].Split(' ')[0].Trim();
                passwordwithrule.letter = line.Split(':')[0].Split(' ')[1].Trim();
                passwordwithrule.password = line.Split(':')[1].Trim();
                formattedlist.Add(passwordwithrule);
            }
            return formattedlist;
        }

        static List<String> PassDataToList(string datapath)
        {
            return System.IO.File.ReadLines(datapath).ToList();
        }
    }
    class PasswordWithRule
    {
        public string rule { get; set; }
        public string letter { get; set; }
        public string password { get; set; }
    }
}
