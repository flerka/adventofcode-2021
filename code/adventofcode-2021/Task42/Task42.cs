using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adventofcode_2021.Task42
{
    public class Solution
    {
        private static Dictionary<int, int> ValuesMap = new()
        {
            { 3, 1 },
            { 4, 3 },
            { 5, 6 },
            { 7, 6 },
            { 8, 3 },
            { 9, 1 },
            { 6, 7 }
        };
        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/21/ task
        /// </summary>
        public static ulong Function(ulong firstStart, ulong secondStart)
        {
            var firstWins = 0UL;
            var secondWins = 0UL;
            foreach (var map in ValuesMap.Keys)
            {
                var res = Calc((true, firstStart, 0, secondStart, 0), map);

                firstWins += (res.firstWins * (ulong)ValuesMap[map]); ;
                secondWins += (res.secondWinds * (ulong)ValuesMap[map]);
            }

            return Math.Max(firstWins, secondWins);
        }

        static private (ulong firstWins, ulong secondWinds) Calc((bool first, ulong fCount, ulong fSum, ulong sCount, ulong sSum) val, int dice)
        {
            (ulong firstWinds, ulong secondWinds) wins = (0, 0);
            if (val.first)
            {
                val.fCount = (((ulong)dice + val.fCount) % 10);
                val.fSum += (val.fCount == 0 ? 10 : val.fCount);
            }
            else
            {
                val.sCount = (((ulong)dice + val.sCount) % 10);
                val.sSum += (val.sCount == 0 ? 10 : val.sCount);
            }

            if (val.fSum >= 21 || val.sSum >= 21)
            {
                return val.fSum >= 21 ? (1UL, 0UL) : (0UL, 1UL);
            }

            val.first = !val.first;
            foreach (var map in ValuesMap.Keys)
            {
                var res = Calc(val, map);
                wins.firstWinds += (res.firstWins * (ulong) ValuesMap[map]);
                wins.secondWinds += (res.secondWinds * (ulong)ValuesMap[map]);
            }

            return wins;
        }
    }
}