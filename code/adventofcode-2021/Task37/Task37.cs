using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task37
{
    public class Point
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

        public static Point Sum(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }

        public static Point Minus(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }
    }

    public class Transform
    {
        public Point Scanner { get; set; }
        public List<Point> Beacons { get; set; }    
    }

    public class ScannerData
    {
        public List<Point> Items { get; set; } = new();
        public int Id { get; set; }
    }

    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/19/ task
        /// </summary>
        public static int Function(List<ScannerData> data)
        {
            return 0;
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
            };
        }
    }
}