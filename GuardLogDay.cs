using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2018
{
    class GuardLogDay
    {
        public int GuardID { get; private set; }
        public DateTime Date { get; private set; }
        public bool[] MinutesAsleep { get; private set; }

        public GuardLogDay()
        {
        }

        public GuardLogDay(int guardID, DateTime date)
        {
            MinutesAsleep = new bool[60];
            GuardID = guardID;
            Date = date;
        }
        
        // Minutes are 0 indexed. Uses a naive algo with a lot of extra work.
        // Fully extends both setting asleep and waking up. 
        // TODO tighten this up by only setting the minutes that need it.
        public void SetMinutesAsleep(int startMin)
        {
            for (int i = startMin; i < 60; i++)
            {
                MinutesAsleep[i] = true;
            }
        }

        // TODO tighten this up by only setting the minutes that need it.
        public void SetMinutesAwake(int startMin)
        {
            for (int i = startMin; i < 60; i++)
            {
                MinutesAsleep[i] = false;
            }
        }

        public int GetMinutesAsleep()
        {
            int sleepCount = 0;

            foreach (var min in MinutesAsleep)
            {
                if (min)
                {
                    sleepCount++;
                }
            }
            return sleepCount;
        }
    }
}
