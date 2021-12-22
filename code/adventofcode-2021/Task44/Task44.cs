using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adventofcode_2021.Task44
{

    public record struct InputData(bool op, long ux, long vx, long uy, long vy, long uz, long vz);

    public class Solution
    {
        private static long Run(List<InputData> data)
        {
            var cubes  = new List<InputData>();
            var newCubes = new List<InputData>(cubes);

            for (var i = 0; i < data.Count; i++)
            {
                var item = data[i];
                foreach (var item2 in cubes)
                {
                    if (item.ux > item2.vx
                        || item.vx < item2.ux
                        || item.uy > item2.vy
                        || item.vy < item2.uy
                        || item.uz > item2.vz
                        || item.vz < item2.uz)
                    {

                        continue;
                    }

                    newCubes.Remove(item2);
                    if (item.ux > item2.ux)
                    {
                        newCubes.Add(new InputData(true, item2.ux, item.ux - 1, item2.uy, item2.vy, item2.uz, item2.vz));
                    }

                    if (item.vx < item2.vx)
                    {
                        newCubes.Add(new InputData(true, item.vx + 1, item2.vx, item2.uy, item2.vy, item2.uz, item2.vz));
                    }

                    if (item.uy > item2.uy)
                    {
                        newCubes.Add(new InputData(true, Math.Max(item2.ux, item.ux), Math.Min(item2.vx, item.vx), item2.uy, item.uy - 1, item2.uz, item2.vz));
                    }

                    if (item.vy < item2.vy)
                    {
                        newCubes.Add(new InputData(true, Math.Max(item2.ux, item.ux), Math.Min(item2.vx, item.vx), item.vy + 1, item2.vy, item2.uz, item2.vz));
                    }

                    if (item.uz > item2.uz)
                    {
                        newCubes.Add(new InputData(true, Math.Max(item2.ux, item.ux), Math.Min(item2.vx, item.vx), Math.Max(item2.uy, item.uy), Math.Min(item2.vy, item.vy), item2.uz, item.uz - 1));
                    }

                    if (item.vz < item2.vz)
                    {
                        newCubes.Add(new InputData(true, Math.Max(item2.ux, item.ux), Math.Min(item2.vx, item.vx), Math.Max(item2.uy, item.uy), Math.Min(item2.vy, item.vy), item.vz + 1, item2.vz));
                    }
                }
                if (item.op)
                {
                    newCubes.Add(new InputData(true, Math.Min(item.ux, item.vx), Math.Max(item.ux, item.vx), Math.Min(item.uy, item.vy), Math.Max(item.uy, item.vy), Math.Min(item.uz, item.vz), Math.Max(item.uz, item.vz)));
                }
                cubes = new List<InputData>(newCubes);
            }
            
            var onCount = 0L;
            foreach(var cube in cubes)
            {
                onCount += (cube.vx - cube.ux + 1L) * (cube.vy - cube.uy + 1L) * (cube.vz - cube.uz + 1L);
            }

            return onCount;
        }


        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/22/ task.
        /// Based on solution https://www.reddit.com/r/adventofcode/comments/rlxhmg/2021_day_22_solutions/hpiz583/ of reddit user and adapted to C#.
        /// </summary>
        public static long Function(IEnumerable<InputData> data)
        {
            return Run(data.ToList());
        }
    }
}