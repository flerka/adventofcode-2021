using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task4
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/2/ task
        /// </summary>
        public static int Function(IEnumerable<string> input)
        {
            return input.Aggregate((distance: 0, aim: 0, depth: 0), (r, next) =>
                next.Split(' ') switch { var t => (t[0], int.Parse(t[1])) } switch
                {
                    ("forward", var val) => (r.distance + val, r.aim, r.depth + r.aim * val),
                    ("up", var val) => (r.distance, r.aim - val, r.depth),
                    ("down", var val) => (r.distance, r.aim + val, r.depth),
                    _ => throw new ArgumentException("Invalid string value for command"),
                }, result => result.distance * result.depth);
        }
    }
}