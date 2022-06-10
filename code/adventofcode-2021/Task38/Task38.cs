using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task38
{
    public struct Point : IEquatable<Point>
    {
        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public override bool Equals(object p)
        {
            Point p2 = (Point)p;
            return X == p2.X && Y == p2.Y && Z == p2.Z;
        }

        public bool Equals(Point p)
        {
            return X == p.X && Y == p.Y && Z == p.Z;
        }

        public override int GetHashCode()
        {
            return X * 31 + Y * 17 + Z;
        }

        public Point Sum(Point p2)
        {
            return new Point(this.X + p2.X, this.Y + p2.Y, this.Z + p2.Z);
        }

        public Point Minus(Point p2)
        {
            return new Point(this.X - p2.X, this.Y - p2.Y, this.Z - p2.Z);
        }
    }

    public class Transform
    {
        public Point Scanner { get; set; }
        public HashSet<Point> Beacons { get; set; }
    }

    public class TaskSolution
    {
        public List<Point> Scanners { get; set; } = new();
        public List<Point> Beacons { get; set; } = new();
    }

    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/19/ task
        /// Based on https://todd.ginsberg.com/post/advent-of-code/2021/day19/ solution
        /// </summary>
        public static int Function(List<HashSet<Point>> data)
        {
            var baseS = data[0];
            HashSet<Point> foundS = new();
            Queue<HashSet<Point>> unmapped = new Queue<HashSet<Point>>(data.Skip(1));
            while (unmapped.Count > 0)
            {
                var sector = unmapped.Dequeue();
                var transform = GetTransformIfIntersect(baseS, sector);
                if (transform != null)
                {
                    baseS.UnionWith(transform.Beacons);
                    foundS.Add(transform.Scanner);
                }
                else
                {
                    unmapped.Enqueue(sector);
                }
            }
            var res = new List<int>();
            foreach (var item in foundS)
            {
                res.AddRange(foundS.Select(f =>
                {
                    var m = f.Minus(item);
                    return Math.Abs(m.Z) + Math.Abs(m.Y) + Math.Abs(m.X);
                }));
            }

            return res.Max();
        }

        private static Transform GetTransformIfIntersect(HashSet<Point> left, HashSet<Point> right)
        {
            for (var i = 0; i < 24; i++)
            {
                var rightRer = Rotate(right, i);
                foreach (var s1 in left)
                {
                    foreach (var s2 in rightRer)
                    {
                        var diff = s1.Minus(s2);
                        var moved = rightRer.Select(x => x.Sum(diff)).ToHashSet<Point>();
                        if (moved.Count(x => left.Contains(x)) >= 12)
                        {
                            return new Transform { Scanner = diff, Beacons = moved };
                        }
                    }
                }
            }

            return null;
        }

        private static List<Point> Rotate(HashSet<Point> points, int i)
        {
            return points.Select(p => Rotate(p, i)).ToList();
        }

        private static Point Rotate(Point p, int i)
        {
            var x = p.X;
            var y = p.Y;
            var z = p.Z;

            return i switch
            {
                0 => new Point(x, y, z),
                1 => new Point(x, z, -y),
                2 => new Point(x, -y, -z),
                3 => new Point(x, -z, y),
                4 => new Point(y, x, -z),
                5 => new Point(y, z, x),
                6 => new Point(y, -x, z),
                7 => new Point(y, -z, -x),
                8 => new Point(z, x, y),
                9 => new Point(z, y, -x),
                10 => new Point(z, -x, -y),
                11 => new Point(z, -y, x),
                12 => new Point(-x, y, -z),
                13 => new Point(-x, z, y),
                14 => new Point(-x, -y, z),
                15 => new Point(-x, -z, -y),
                16 => new Point(-y, x, z),
                17 => new Point(-y, z, -x),
                18 => new Point(-y, -x, -z),
                19 => new Point(-y, -z, x),
                20 => new Point(-z, x, -y),
                21 => new Point(-z, y, x),
                22 => new Point(-z, -x, y),
                23 => new Point(-z, -y, -x),
                _ => throw new Exception("Unsupported input")
            };
        }
    }
}