using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace adventofcode_2021.Task49
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/25/ task
        /// </summary>
        public static int Function(List<char[]> input)
        {
            var count = 1;
            var data = input;
            while(true)
            {
                var resR = MoveRight(data);
                data = resR.newList;
                var resD = MoveDown(data);
                data = resD.newList;
                if (resR.count == 0 && resD.count == 0)
                {
                    return count;
                }

                count++;
            }
        }

        private static (int count, List<char[]> newList) MoveRight(List<char[]> input)
        {
            var newList = input.Select(x => x.ToArray()).ToList();
            var updated = 0;

            for (var k = 0; k < input.Count; k++)
            {
                for (var i = 0; i < input[k].Length; i++)
                {
                    var c = input[k][i];
                    if (c == '>')
                    {
                        if (i == (input[k].Length - 1))
                        {
                            if (input[k][0] == '.')
                            {
                                updated++;
                                newList[k][0] = '>';
                                newList[k][i] = '.';
                            }
                        }
                        else
                        {
                            if (input[k][i + 1] == '.')
                            {
                                updated++;
                                newList[k][i + 1] = '>';
                                newList[k][i] = '.';
                            }
                        }
                    }
                }
            }

            return (updated, newList);
        }

        private static (int count, List<char[]> newList) MoveDown(List<char[]> input)
        {
            var newList = input.Select(x => x.ToArray()).ToList();
            var updated = 0;

            for (var k = 0; k < input.Count; k++)
            {
                for (var i = 0; i < input[k].Length; i++)
                {
                    var c = input[k][i];
                    if (c == 'v')
                    {
                        if (k == (input.Count - 1))
                        {
                            if (input[0][i] == '.')
                            {
                                updated++;
                                newList[0][i] = 'v';
                                newList[k][i] = '.';
                            }
                        }
                        else
                        {
                            if (input[k + 1][i] == '.')
                            {
                                updated++;
                                newList[k + 1][i] = 'v';
                                newList[k][i] = '.';
                            }
                        }
                    }
                }
            }


            return (updated, newList);
        }
    }
}