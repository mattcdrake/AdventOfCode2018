using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2018
{
    class GuardLogDay
    {
        public int GuardID { get; private set; }
        public int Day { get; private set; } 
        public int Month { get; private set; }
        public int Year { get; private set; }
        public int MinutesAsleepCount { get; private set; }
        public bool[] MinutesAsleep { get; private set; }

        public GuardLogDay()
        {
        }

        public GuardLogDay(int guardID, int day, int month, int year)
        {
            MinutesAsleep = new bool[60];
            MinutesAsleepCount = 0;
            GuardID = guardID;
            Day = day;
            Month = month;
            Year = year;
        }
        
        // Minutes are 0 indexed. Uses a naive algo with a lot of extra work.
        // Fully extends both setting asleep and waking up. 
        // TODO tighten this up by only setting the minutes that need it.
        public void SetMinutesAsleep(int startMin)
        {
            for (int i = startMin; i < 60; i++)
            {
                MinutesAsleep[i] = true;
                MinutesAsleepCount++;
            }
        }

        // TODO tighten this up by only setting the minutes that need it.
        public void SetMinutesAwake(int startMin)
        {
            for (int i = startMin; i < 60; i++)
            {
                if (MinutesAsleep[i])
                {
                    MinutesAsleepCount--;
                }
                MinutesAsleep[i] = false;
            }
        }

        public int GetMinutesAsleep()
        {
            return MinutesAsleepCount;
        }
    }
}
