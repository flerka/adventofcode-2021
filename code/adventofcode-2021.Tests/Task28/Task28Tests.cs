using adventofcode_2021.Task28;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2022.Tests
{
    public class Task28Tests
    {
        [Fact]
        public void Task28_RealExample_Correct()
        {
            Assert.Equal((ulong)2188189693529, Solution.Function(ReadFileAsync(Path.Combine("Task28", "Data.txt"))));
        }

        private (string, List<(string, string)>) ReadFileAsync(string file)
        {
            var text = File.ReadAllLines(file);
            var start = text.First();

            var pattern = text.Skip(2).Select(item => 
            {
                var items = item.Split(" -> ");
                return (items[0], items[1]);
            }).ToList();

            return (start, pattern);
        }
    }
}
