using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode_2021.Task47
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/24/ task.
        /// This solution is very slow. The result solution was manual and based 
        /// on this https://github.com/mebeim/aoc/blob/master/2021/README.md#day-24---arithmetic-logic-unit article.
        /// </summary>
        public static ulong Function()
        {
            Dictionary<int, (int x, int y, int z)> constsDict = new()
            {
                { 0, (15, 13, 1) },
                { 1, (10, 16, 1) },
                { 2, (12, 2, 1) },
                { 3, (10, 8, 1) },
                { 4, (14, 11, 1) },
                { 5, (-11, 6, 26) },
                { 6, (10, 12, 1) },
                { 7, (-16, 2, 26) },
                { 8, (-9, 2, 26) },
                { 9, (11, 15, 1) },
                { 10, (-8, 1, 26) },
                { 11, (-8, 10, 26) },
                { 12, (-10, 14, 26) },
                { 13, (-9, 10, 26) }
            };

            List <Dictionary<(int x, int y, int z, int w), (int x, int y, int z, int w)>> cache = new() {
                new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new(), new() };

            for (ulong val = 99999999999999; val >= 11111111111111; val--)
            {
                var valstr = val.ToString();
                if (valstr.Contains('0'))
                {
                    continue;
                }

                (int x, int y, int z, int w) variables = (0, 0, 0, 0);
                for (int i = 0; i < 14; i++)
                {
                    variables.w = valstr[i] - '0';
                    if (cache[i].ContainsKey(variables))
                    {
                        variables = cache[i][variables];
                    }
                    else
                    {
                        var res = Solve( variables, constsDict[i]);
                        cache[i][variables] = res;

                        if (res.z == 0)
                        {
                            return val;
                        }
                    }
                }
            }

            throw new Exception("result should be found");
        }

        private static (int x, int y, int z, int w) Solve((int x, int y, int z, int w) variables, (int addx, int addy, int divz) consts)
        {
            var x = variables.x;
            var y = variables.y;
            var z = variables.z;
            var w = variables.w;

            mul(ref x, 0);
            add(ref x, z);
            mod(ref x, 26);
            div(ref z, consts.divz);
            add(ref x, consts.addx);
            eql(ref x, w);
            eql(ref x, 0);
            mul(ref y, 0);
            add(ref y, 25);
            mul(ref y, x);
            add(ref y, 1);
            mul(ref z, y);
            mul(ref y, 0);
            add(ref y, w);
            add(ref y, consts.addy);
            mul(ref y, x);
            add(ref z, y);

            return (x, y, z, w);
        }

        private static void inp(ref int val1, ulong val2)
        {
            var s = val2.ToString();
            val1 = s[0] - '0';
        }

        private static void add(ref int val1, int val2)
        {
            val1 = val1 + val2;
        }

        private static void mul(ref int val1, int val2)
        {
            val1 = val1 * val2;
        }

        private static void mod(ref int val1, int val2)
        {
            val1 = val1 % val2;
        }

        private static void div(ref int val1, int val2)
        {
            val1 = val1 / val2;
        }

        private static void eql(ref int val1, int val2)
        {
            val1 = val1 == val2 ? 1 : 0;
        }
    }
}