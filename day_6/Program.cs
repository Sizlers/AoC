using System;
using System.Collections.Generic;
using System.Linq;

namespace day_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var formattedData = FormatData("assets/input.txt");
            int result1 = QuestionOne(formattedData);
            Console.WriteLine("The result to question one is: {0}", result1);
            int result2 = QuestionTwo(formattedData);
            Console.WriteLine("The result to question two is: {0}", result2);
        }
        static int QuestionOne(string[] data)
        {
            int sum = 0;
            foreach (string group in data)
            {
                var uniqueAnwsers = RemoveDuplicates(group.Replace(System.Environment.NewLine, ""));
                sum = sum + uniqueAnwsers.Length;
            }
            return sum;
        }

        static int QuestionTwo(string[] data)
        {
            int count = 0;
            foreach (string group in data)
            {
                string[] groupArray = group.Split(
                new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                char[] commonAnwsers = groupArray[0].ToCharArray();
                foreach (string person in groupArray)
                {
                    char[] comparisonArray = person.ToCharArray();
                    char[] comparedResults = commonAnwsers.Intersect(comparisonArray).ToArray();
                    commonAnwsers = comparedResults;
                }
                count = count + commonAnwsers.Count();
            }
            return count;
        }
        static string[] FormatData(string datapath)
        {
            return System.IO.File.ReadAllText(datapath).Split(
                new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries
            );
        }
        static string RemoveDuplicates(string input)
        {
            return new string(input.ToCharArray().Distinct().ToArray());
        }
    }
}