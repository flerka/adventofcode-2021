using adventofcode_2021.Task37;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace adventofcode_2021.Tests
{
    public class Task37Tests
    {
        [Fact]
        public void Task37_RealExample_Correct()
        {
            Assert.Equal(79, Solution.Function(ReadFileAsync(Path.Combine("Task37", "Data.txt"))));
        }

        private List<HashSet<Point>> ReadFileAsync(string fileName)
        {
            var result = new List<HashSet<Point>>();
            var currentPoints = new HashSet<Point>();
            foreach (var line in File.ReadLines(fileName))
            {
                if (line.StartsWith("--- scanner"))
                {
                    if (currentPoints.Count > 0)
                    {
                        result.Add(currentPoints);
                        currentPoints = new();
                    }
                }
                else if (!string.IsNullOrEmpty(line))
                {
                    var n = line.Split(',').Select(x => int.Parse(x)).ToList();
                    currentPoints.Add(new Point (n[0], n[1], n[2]));
                }
            }

            result.Add (currentPoints);
            return result;
        }
    }
}
