using Advent2018;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2018
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
            // First pass to create all the days
            foreach (var line in InputLines)
            {
                string[] tokens = line.Split();
                bool isGuardString = tokens[2] == "Guard" ? true : false;

                if (isGuardString)
                {
                    string[] dateTokens = tokens[0].Split('-');
                    int day = int.Parse(dateTokens[2]);
                    int month = int.Parse(dateTokens[1]);
                    int year = int.Parse(dateTokens[0].Substring(1));

                    string[] timeTokens = tokens[1].Split(':');
                    int hour = int.Parse(timeTokens[0]);

                    DateTime date = new DateTime(year, month, day);

                    if (isGuardString && hour > 0)
                    {
                        date = date.AddDays(1);
                    }

                    int guardId = int.Parse(tokens[3].Substring(1));
                    GuardLogDay workingDay = new GuardLogDay(guardId, date);
                    _GuardLogEntries[date] = workingDay;
                }
            }

            // Second pass for the times
            foreach (var line in InputLines)
            {
                string[] tokens = line.Split();
                bool isGuardString = tokens[2] == "Guard" ? true : false;

                if (!isGuardString)
                {
                    string[] dateTokens = tokens[0].Split('-');
                    int day = int.Parse(dateTokens[2]);
                    int month = int.Parse(dateTokens[1]);
                    int year = int.Parse(dateTokens[0].Substring(1));

                    string[] timeTokens = tokens[1].Split(':');
                    int minute = int.Parse(timeTokens[1].Substring(0, timeTokens[1].Length - 1));

                    DateTime date = new DateTime(year, month, day);

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
            return "temp2";
        }

        private int FindSleepiestGuard()
        {
            if (_GuardLogEntries.Count == 0)
            {
                return 0;
            }
            Dictionary<int, int> GuardSleepTracker = new Dictionary<int, int>();

            foreach (var dayLog in _GuardLogEntries.Values)
            {
                if (GuardSleepTracker.ContainsKey(dayLog.GuardID))
                {
                    GuardSleepTracker[dayLog.GuardID] += dayLog.GetMinutesAsleep();
                }
                else
                {
                    GuardSleepTracker[dayLog.GuardID] = dayLog.GetMinutesAsleep();
                }
            }

            return GuardSleepTracker.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
        }

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
