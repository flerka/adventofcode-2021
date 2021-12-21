using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adventofcode_2021.Task41
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/21/ task
        /// </summary>
        public static int Function(int firstStart, int secondStart)
        {
            var count = 1;
            var stepsCount = 0;
            var firstSum = 0;
            var secondSum = 0;
            var firstCount = firstStart;
            var secondCoumt = secondStart;
            var dieRolls = 0;

            while (firstSum < 1000 && secondSum < 1000)
            {
                firstCount = (((count % 10) * 3 + 3 + firstCount) % 10);
                firstSum += (firstCount == 0 ? 10 : firstCount);
                dieRolls += 3;
                count += 3;

                if (firstSum < 1000)
                {
                    secondCoumt = (((count % 10) * 3 + 3 + secondCoumt) % 10);
                    secondSum += (secondCoumt == 0 ? 10 : secondCoumt);
                    dieRolls += 3;
                    count += 3;

                }

                stepsCount++;
            }

            return firstSum > secondSum ? secondSum * dieRolls : firstSum * dieRolls;
        }
    }
}