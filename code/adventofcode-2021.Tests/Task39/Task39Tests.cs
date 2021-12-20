﻿using adventofcode_2021.Task39;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace adventofcode_2022.Tests
{
    public class Task39Tests
    {
        public Task39Tests(ITestOutputHelper output)
        {
            var converter = new Converter(output);
            Console.SetOut(converter);
        }

        [Fact]
        public void Task39_RealExample_Correct()
        {
            Assert.Equal(35, Solution.Function(ReadFileAsync(Path.Combine("Task39", "Data.txt"))));
        }

        private (string, List<string>) ReadFileAsync(string fileName)
        {
            string algorithmString = string.Empty;
            bool shouldReadImage = false;
            List<string> result = new();
            var dots = new string('.', 4);

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
            for (int i = 0; i < 4; i++) 
            {
                resultWithBorder.Add(new string('.', result[0].Length));
            }

            resultWithBorder.AddRange(result);

            for (int i = 0; i < 4; i++)
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
