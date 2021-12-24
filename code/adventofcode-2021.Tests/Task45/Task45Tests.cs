using adventofcode_2021.Task45;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace adventofcode_2022.Tests
{
    public class Task45Tests
    {
        [Fact]
        public void Task45_RealExample_Correct()
        {
            Assert.Equal(12521, Solution.Function(ReadFileAsync(Path.Combine("Task45", "Data.txt"))));
        }

        private List<string> ReadFileAsync(string fileName)
        {
            var pairs = File.ReadAllLines(fileName)[0].Split(',').ToList();
            return pairs;
            //return new InputData(
            //    (pairs[0][0], pairs[0][1]),
            //    (pairs[1][0], pairs[1][1]), 
            //    (pairs[2][0], pairs[2][1]), 
            //    (pairs[3][0], pairs[3][1]));
        }
    }
}