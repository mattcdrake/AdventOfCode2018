using AdventOfCode2018;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;

namespace AdventOfCode2018
{
    internal sealed class Day4 : Day
    {
        private Dictionary<DateTime, GuardLogDay> _GuardLogEntries;

        public Day4()
        {
            InputLines = Helpers.ParseInputLines("input_data\\day4.txt");
            InputLines.Sort();
            _GuardLogEntries = new Dictionary<DateTime, GuardLogDay>();
            Solution1 = Solve1();
            Solution2 = Solve2();
        }

        protected override string Solve1()
        {
            // Avoids compiler error about uninitialized GuardLogDay
            GuardLogDay workingDay = new GuardLogDay();

            // First pass to create all the days
            foreach (var line in InputLines)
            {
                string[] tokens = line.Split();
                bool isGuardString = tokens[2] == "Guard" ? true : false;

                string[] dateTokens = tokens[0].Split('-');
                int day = int.Parse(dateTokens[2]);
                int month = int.Parse(dateTokens[1]);
                int year = int.Parse(dateTokens[0].Substring(1));

                string[] timeTokens = tokens[1].Split(':');
                int hour = int.Parse(timeTokens[0]);
                int minute = int.Parse(timeTokens[1].Substring(0, timeTokens[1].Length - 1));

                DateTime date = new DateTime(year, month, day);

                if (isGuardString)
                {
                    if (hour > 0)
                    {
                        date = date.AddDays(1);
                    }
                    int guardId = int.Parse(tokens[3].Substring(1));
                    workingDay = new GuardLogDay(guardId, date);
                    _GuardLogEntries[date] = workingDay;
                }
                else
                {
                    if (tokens[2] == "falls")
                    {
                        _GuardLogEntries[date].SetMinutesAsleep(minute);
                    }
                    else
                    {
                        _GuardLogEntries[date].SetMinutesAwake(minute);
                    }
                }
            }

            int sleepiestGuard = FindSleepiestGuard();
            int sleepiestMinute = FindSleepiestMinute(sleepiestGuard);

            return (sleepiestGuard * sleepiestMinute).ToString();
        }

        protected override string Solve2()
        {
            // Maps guard id to a dictionary which contains counts of how often that guard was asleep
            // on that specific minute.
            Dictionary<int, Dictionary<int, int>> guardToMinCounts = new Dictionary<int, Dictionary<int, int>>();

            foreach (var log in _GuardLogEntries)
            {
                var guardId = log.Value.GuardID;
                var minuteArray = log.Value.MinutesAsleep;

                for (var i = 0; i < minuteArray.Length; ++i)
                {
                    if (!minuteArray[i]) continue;

                    if (!guardToMinCounts.ContainsKey(guardId))
                    {
                        guardToMinCounts[guardId] = new Dictionary<int, int>();
                    }

                    if (guardToMinCounts[guardId].ContainsKey(i))
                    {
                        guardToMinCounts[guardId][i]++;
                    }
                    else
                    {
                        guardToMinCounts[guardId][i] = 1;
                    }
                }
            }

            int sleepyGuard = 0;
            int sleepiestMinute = 0;
            int highestSleepyMinuteCount = 0;

            foreach (var guardDict in guardToMinCounts)
            {
                var sleepyMinute = guardDict.Value.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
                if (guardDict.Value[sleepyMinute] > highestSleepyMinuteCount)
                {
                    sleepyGuard = guardDict.Key;
                    sleepiestMinute = sleepyMinute;
                    highestSleepyMinuteCount = guardDict.Value[sleepyMinute];
                }
            }

            return (sleepyGuard * sleepiestMinute).ToString();
        }

        // Returns ID of the guard who was most often asleep (total cumulative minutes)
        private int FindSleepiestGuard()
        {
            if (_GuardLogEntries.Count == 0)
            {
                return 0;
            }
            Dictionary<int, int> guardSleepTracker = new Dictionary<int, int>();

            foreach (var dayLog in _GuardLogEntries.Values)
            {
                if (guardSleepTracker.ContainsKey(dayLog.GuardID))
                {
                    guardSleepTracker[dayLog.GuardID] += dayLog.GetMinutesAsleep();
                }
                else
                {
                    guardSleepTracker[dayLog.GuardID] = dayLog.GetMinutesAsleep();
                }
            }

            return guardSleepTracker.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
        }

        // Returns the minute during which a particular guard was most often asleep
        private int FindSleepiestMinute(int guardID)
        {
            Dictionary<int, int> MinuteSleptTracker = new Dictionary<int, int>();

            // Done just to avoid having to initialize minutes as we traverse the
            // minute array.
            for (int i = 0; i < 60; i++)
            {
                MinuteSleptTracker[i] = 0;
            }

            foreach (var day in _GuardLogEntries.Values)
            {
                if (day.GuardID == guardID)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        if (day.MinutesAsleep[i])
                        {
                            MinuteSleptTracker[i]++;
                        }
                    }
                }
            }

            return MinuteSleptTracker.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
        }
    }
}
