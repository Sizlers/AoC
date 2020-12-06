using System;
using System.Collections.Generic;
using System.IO;

namespace day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] seats = File.ReadAllLines("assets/input.txt");
            List<int> seatIds = new List<int>();
            foreach (string seat in seats)
            {
                var boardingpass = new BoardingPass(seat);
                seatIds.Add(boardingpass.SeatId);
            }
            //this isn't great, there must be a better way of doing this?
            seatIds.Sort();
            seatIds.Reverse();
            Console.WriteLine("The highest seat ID is: {0}", seatIds[0]);

            int count = seatIds[0];

            foreach (int id in seatIds)
            {
                if (count != id)
                {
                    Console.WriteLine("My seat ID is: {0}", id + 1);
                    break;
                }
                count--;
            }
        }
    }
    class BoardingPass
    {
        int _columnLowerHalf = 0;
        int _columnUpperHalf = 127;
        int _rowLowerHalf = 0;
        int _rowUpperHalf = 7;
        public int SeatId { get; set; }
        public BoardingPass(string code)
        {
            char[] codeArray = code.ToCharArray();
            foreach (char zone in codeArray)
            {
                eliminateZone(zone);
            }
            SeatId = _columnUpperHalf * 8 + _rowUpperHalf;
        }
        void eliminateZone(char zone)
        {
            switch (zone)
            {
                case 'F':
                    _columnUpperHalf = (_columnUpperHalf + _columnLowerHalf) / 2;
                    break;
                case 'B':
                    _columnLowerHalf = (_columnUpperHalf + _columnLowerHalf) / 2;
                    break;
                case 'R':
                    _rowLowerHalf = (_rowUpperHalf + _rowLowerHalf) / 2;
                    break;
                case 'L':
                    _rowUpperHalf = (_rowUpperHalf + _rowLowerHalf) / 2;
                    break;
                default:
                    //should an exception be thrown like this?
                    throw new System.ArgumentException("The zone provided is not valid.", zone.ToString());
            }
        }
    }
}