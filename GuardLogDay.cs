using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2018
{
    class GuardLogDay
    {
        public int GuardID, Day, Month, Year;
        public bool[] MinutesAsleep;

        public GuardLogDay(int guardID, int day, int month, int year)
        {
            MinutesAsleep = new bool[60];
            GuardID = guardID;
            Day = day;
            Month = month;
            Year = year;
        }

        // Minutes are 0 indexed
        public void SetMinutesAsleep(int startMin, int countMin)
        {
            for (int i = startMin; i < startMin + countMin; i++)
            {
                MinutesAsleep[i] = true;
            }
        }
    }
}
