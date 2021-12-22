using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task43
{
    public record struct Cuboid(bool op, int lowerX, int upperX, int lowerY, int upperY, int lowerZ, int upperZ);

    public class Solution
    {
        private static int Test(List<Cuboid> data)
        {
            var cubes = new List<Cuboid>();
            var newCubes = new List<Cuboid>(cubes);

            for (var i = 0; i < data.Count; i++)
            {
                var item = data[i];
                foreach (var item2 in cubes)
                {
                    if (item.lowerX > item2.upperX
                        || item.upperX < item2.lowerX
                        || item.lowerY > item2.upperY
                        || item.upperY < item2.lowerY
                        || item.lowerZ > item2.upperZ
                        || item.upperZ < item2.lowerZ)
                    {

                        continue;
                    }

                    newCubes.Remove(item2);
                    if (item.lowerX > item2.lowerX)
                    {
                        newCubes.Add(new Cuboid(
                            true, item2.lowerX, item.lowerX - 1, item2.lowerY,
                            item2.upperY, item2.lowerZ, item2.upperZ));
                    }

                    if (item.upperX < item2.upperX)
                    {
                        newCubes.Add(new Cuboid(
                            true, item.upperX + 1, item2.upperX,
                            item2.lowerY, item2.upperY, item2.lowerZ, item2.upperZ));
                    }

                    if (item.lowerY > item2.lowerY)
                    {
                        newCubes.Add(new Cuboid(
                            true, Math.Max(item2.lowerX, item.lowerX),
                            Math.Min(item2.upperX, item.upperX),
                            item2.lowerY, item.lowerY - 1, item2.lowerZ, item2.upperZ));
                    }

                    if (item.upperY < item2.upperY)
                    {
                        newCubes.Add(new Cuboid(
                            true, Math.Max(item2.lowerX, item.lowerX),
                            Math.Min(item2.upperX, item.upperX),
                            item.upperY + 1, item2.upperY, item2.lowerZ, item2.upperZ));
                    }

                    if (item.lowerZ > item2.lowerZ)
                    {
                        newCubes.Add(new Cuboid(
                            true, Math.Max(item2.lowerX, item.lowerX),
                            Math.Min(item2.upperX, item.upperX), Math.Max(item2.lowerY, item.lowerY),
                            Math.Min(item2.upperY, item.upperY), item2.lowerZ, item.lowerZ - 1));
                    }

                    if (item.upperZ < item2.upperZ)
                    {
                        newCubes.Add(new Cuboid(
                            true, Math.Max(item2.lowerX, item.lowerX), Math.Min(item2.upperX, item.upperX),
                            Math.Max(item2.lowerY, item.lowerY), Math.Min(item2.upperY, item.upperY),
                            item.upperZ + 1, item2.upperZ));
                    }
                }

                if (item.op)
                {
                    newCubes.Add(new Cuboid(
                        true, Math.Min(item.lowerX, item.upperX), 
                        Math.Max(item.lowerX, item.upperX), Math.Min(item.lowerY, item.upperY),
                        Math.Max(item.lowerY, item.upperY), Math.Min(item.lowerZ, item.upperZ), 
                        Math.Max(item.lowerZ, item.upperZ)));
                }
                cubes = new List<Cuboid>(newCubes);
            }

            var onCount = 0;
            foreach (var cube in cubes)
            {
                onCount += (cube.upperX - cube.lowerX + 1) * (cube.upperY - cube.lowerY + 1) * (cube.upperZ - cube.lowerZ + 1);
            }

            return onCount;
        }

        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/22/ task.
        /// Based on solution https://www.reddit.com/r/adventofcode/comments/rlxhmg/2021_day_22_solutions/hpiz583/ of reddit user and adapted to C#.
        /// </summary>
        public static int Function(IEnumerable<Cuboid> data)
        {
            return Test(data.ToList());
        }
    }
}