using adventofcode_2021.Task32;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace adventofcode_2021.Tests
{
    public class Task32Tests
    {
        [Fact]
        public void Task32_RealExample_Correct()
        {
            Assert.Equal(333794664059UL, Solution.Function(ReadFileAsync(Path.Combine("Task32", "Data.txt"))));
        }

        private string ReadFileAsync(string file)
        {
            var strings = File.ReadLines(file).ElementAt(0).ToCharArray().Select(item =>
            {
                return item switch
                {
                    '0' => "0000",
                    '1' => "0001",
                    '2' => "0010",
                    '3' => "0011",
                    '4' => "0100",
                    '5' => "0101",
                    '6' => "0110",
                    '7' => "0111",
                    '8' => "1000",
                    '9' => "1001",
                    'A' => "1010",
                    'B' => "1011",
                    'C' => "1100",
                    'D' => "1101",
                    'E' => "1110",
                    'F' => "1111",
                    _ => throw new Exception("Unsupported input")
                };
            }).ToList();
            return String.Join(string.Empty, strings);
        }
    }
}
