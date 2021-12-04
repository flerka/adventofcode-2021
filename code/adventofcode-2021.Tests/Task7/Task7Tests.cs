using Xunit;
using adventofcode_2021.Task7;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace adventofcode_2021.Tests
{
    public class Task7Tests
    {
        [Fact]
        public void Task7_RealExample_Correct()
        {
            var (numbers, boards, boardsDict) = ReadFileAsync(Path.Combine("Task7", "Data.txt"));
            Assert.Equal(4512, Solution.Function(numbers, boards, boardsDict));
        }

        private (List<int>, List<int[,]>, List<Dictionary<int, (int, int)>>) ReadFileAsync(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            var bingoNumbers = lines.First().Split(',').Select(int.Parse).ToList();
            var bingoBoards = new List<int[,]>();
            var bingoBoardsDict = new List<Dictionary<int, (int, int)>>();

            var skipLines = 2; 
            var bingoSize = 5;

            while (skipLines < lines.Length)
            {
                var bingoItem = new int[5, 5];
                Dictionary<int, (int, int)> bingoItemDict = new();

                lines
                .Skip(skipLines)
                .Take(bingoSize)
                .Aggregate(0, (si, nexts) =>
                {
                    nexts.Split(' ', System.StringSplitOptions.RemoveEmptyEntries)
                     .Aggregate(0, (ni, nextn) =>
                     {
                         var val = int.Parse(nextn);
                         bingoItem[si, ni] = val;
                         bingoItemDict[val] = (si, ni);
                         return ni + 1;
                     });
                    return si + 1;
                });
                
                bingoBoards.Add(bingoItem);
                bingoBoardsDict.Add(bingoItemDict);
                skipLines += (bingoSize + 1);
            }

            return (bingoNumbers, bingoBoards, bingoBoardsDict);
        }
    }
}
