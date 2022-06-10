using adventofcode_2021.Task27;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task27Tests
    {
        [Fact]
        public void Task27_RealExample_Correct()
        {
            Assert.Equal(1588, Solution.Function(ReadFileAsync(Path.Combine("Task27", "Data.txt"))));
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
