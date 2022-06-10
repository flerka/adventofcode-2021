using adventofcode_2021.Task40;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace adventofcode_2021.Tests
{
    public class Task40Tests
    {
        public Task40Tests(ITestOutputHelper output)
        {
            var converter = new Converter(output);
            Console.SetOut(converter);
        }

        [Fact]
        public void Task40_RealExample_Correct()
        {
            Assert.Equal(3351, Solution.Function(ReadFileAsync(Path.Combine("Task40", "Data.txt"))));
        }

        private (string, List<string>) ReadFileAsync(string fileName)
        {
            string algorithmString = string.Empty;
            bool shouldReadImage = false;
            List<string> result = new();
            var dots = new string('.', 100);

            foreach (var line in File.ReadLines(fileName))
            {
                if (string.IsNullOrEmpty(line))
                {
                    shouldReadImage = true;
                    continue;
                }

                if (!shouldReadImage)
                {
                    algorithmString += line;
                    continue;
                }

                result.Add($"{dots}{line}{dots}");
            }

            var resultWithBorder = new List<string> ();
            for (int i = 0; i < 100; i++) 
            {
                resultWithBorder.Add(new string('.', result[0].Length));
            }

            resultWithBorder.AddRange(result);

            for (int i = 0; i < 100; i++)
            {
                resultWithBorder.Add(new string('.', result[0].Length));
            }

            return (algorithmString, resultWithBorder);
        }

        private class Converter : TextWriter
        {
            ITestOutputHelper _output;
            public Converter(ITestOutputHelper output)
            {
                _output = output;
            }
            public override Encoding Encoding
            {
                get { return Encoding.Default; }
            }
            public override void WriteLine(string message)
            {
                _output.WriteLine(message);
            }
            public override void WriteLine(string format, params object[] args)
            {
                _output.WriteLine(format, args);
            }

            public override void Write(char value)
            {
                throw new NotSupportedException("This text writer only supports WriteLine(string) and WriteLine(string, params object[]).");
            }
        }
    }
}
