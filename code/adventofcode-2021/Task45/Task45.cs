using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adventofcode_2021.Task45
{
    public record struct InputData((char d, char u) A, (char d, char u) B, (char d, char u) C, (char d, char u) D);

    public class Solution
    {
        private static readonly Dictionary<char, int> AmphipodsEnergy = new Dictionary<char, int>
        {
           {'A', 1 }, {'B', 10}, {'C', 100}, {'D', 1000}
        };

        private const char EmptyChar = 'E';

        private static readonly List<int> CanStopIndex = new()
        {
            0,1, 3, 5, 7, 9,10
        };

        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/23/ task.
        /// </summary>
        public static int Function(List<string> input)
        {
            Dictionary<int, char> corridor = new()
            {
                { 0, EmptyChar },
                { 1, EmptyChar },
                { 2, EmptyChar },
                { 3, EmptyChar },
                { 4, EmptyChar },
                { 5, EmptyChar },
                { 6, EmptyChar },
                { 7, EmptyChar },
                { 8, EmptyChar },
                { 9, EmptyChar },
                { 10, EmptyChar }
            };

            var results = new List<int>();
            for(var i = 0; i < input.Count; i++)
            {
                var res = Solve(corridor, (i, 2));
                if (res != -1)
                {
                    results.Add(res);
                }
            }

            return 0;
        }

        private static int Solve(Dictionary<int, char> corridor, (int, int) index)
        {
            var result = new List<string>();
            foreach(var stop in CanStopIndex)
            {

            }
            return -1;
        }
    }
}