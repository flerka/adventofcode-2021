using adventofcode_2021.Task30;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task30Tests
    {
        [Fact]
        public void Task30_RealExample_Correct()
        {
            Assert.Equal(315, Solution.Function(ReadFileAsync(Path.Combine("Task30", "Data.txt"))));
        }

        private List<List<int>> ReadFileAsync(string file)
        {
            var lines = File.ReadLines(file);
            var count = lines.Count();
            var result = new List<List<int>>();

            foreach (var line in lines)
            {
                var subRes = new List<int>();
                var item = line.ToCharArray().Select(ch => ch - '0').ToList();
                for (int i = 0; i < 5; i++)
                {
                    subRes.AddRange(item);
                }
                result.Add(subRes);
            }

            var items = result;
            var a = (4 * lines.Count());
            for (int i = 0; i < a; i++)
            {
                result.Add(new List<int>(items[i]));
            }

            for (int i = 0;i < result.Count; i++)
            {
                for(int j = 0; j < result.Count; j++)
                {
                    var number = (result[i][j] + i / count + j / count);
                    result[i][j] = number > 9 ? number % 9 : number;
                }
            }

            return result;
        }
    }
}
