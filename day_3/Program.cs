using System;
using System.Collections.Generic;
using System.Linq;

namespace day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> rawData = PassDataToList("assets/input.txt");
            List<MapRow> fomattedRows = MapRow.FormatList(rawData);

            QuestionOne(fomattedRows);
            QuestionTwo(fomattedRows);

        }
        static List<String> PassDataToList(string dataPath)
        {
            return System.IO.File.ReadLines(dataPath).ToList();
        }
        static void QuestionOne(List<MapRow> fomattedRows)
        {
            int result = MapRow.CheckSlope(fomattedRows, 3, 1);
            Console.WriteLine("Question one tree count is: {0}.", result);
        }
        static void QuestionTwo(List<MapRow> fomattedRows)
        {
            int resultOne = MapRow.CheckSlope(fomattedRows, 1, 1);
            int resultTwo = MapRow.CheckSlope(fomattedRows, 3, 1);
            int resultThree = MapRow.CheckSlope(fomattedRows, 5, 1);
            int resultFour = MapRow.CheckSlope(fomattedRows, 7, 1);
            int resultFive = MapRow.CheckSlope(fomattedRows, 1, 2);

            long result =
                Convert.ToInt64(resultOne)
                * Convert.ToInt64(resultTwo)
                * Convert.ToInt64(resultThree)
                * Convert.ToInt64(resultFour)
                * Convert.ToInt64(resultFive)
                ;
            Console.WriteLine("Tree count is: {0}.", result);
        }
    }
    class MapRow
    {
        char[] terrain { get; set; }
        int index { get; set; }
        static bool IsTree(char location)
        {
            return location == '#' ? true : false;
        }
        public static int CheckSlope(List<MapRow> rows, int right, int down)
        {
            int count = 0;
            int index = 0;
            foreach (MapRow row in rows)
            {
                if ((row.index % (down) == 0 || down == 1))
                {
                    int x = (index * right);

                    if (x >= row.terrain.Length)
                    {
                        x = x % row.terrain.Length;
                    }

                    if (IsTree(row.terrain[x]))
                    {
                        count = count + 1;
                    }
                    index++;
                }
            }
            return count;
        }
        public static List<MapRow> FormatList(List<String> rows)
        {
            List<MapRow> formattedList = new List<MapRow>();
            int i = 0;
            foreach (var row in rows)
            {
                var mapRow = new MapRow();
                mapRow.terrain = row.ToCharArray();
                mapRow.index = i;
                formattedList.Add(mapRow);
                i++;
            }
            return formattedList;
        }
    }
}