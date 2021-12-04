using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task8
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/4/ task
        /// </summary>
        public static int Function(List<int> numbers, List<int[,]> boards, List<Dictionary<int, (int, int)>> boardsDict)
        {
            var resultCheck = boards;
            List<int> winnerValues = new();
            List<int> winnedBoards = new();

            for (var i = 0; i < numbers.Count; i++)
            {
                var num = numbers[i];

                boardsDict.Aggregate(0, (r, next) =>
                {
                    if (next.ContainsKey(num))
                    {
                        var (i, j) = next[num];
                        resultCheck[r][i, j] = int.MaxValue;

                        if (IsWinnerBoard(resultCheck[r], i, j) && !winnedBoards.Contains(r))
                        {
                            winnedBoards.Add(r);
                            winnerValues.Add(GetWinValue(resultCheck[r], num));
                        }
                    }
                    return r + 1;
                });
            }

            return winnerValues.Last();
        }

        private static int GetWinValue(int[,] board, int winnerNumber)
        {
            var result = 0;
            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    if (board[i, j] != int.MaxValue)
                    {
                        result += board[i, j];
                    }
                }
            }

            return result * winnerNumber;
        }
        private static bool IsWinnerBoard(int[,] board, int iw, int jw)
        {
            // check horizontally
            var isWinnerHorizontally = true;
            for (var i = 0; i < 5; i++)
            {
                if (board[iw, i] != int.MaxValue)
                {
                    isWinnerHorizontally = false;
                }
            }

            var isWinnerVertically = true;
            for (var i = 0; i < 5; i++)
            {
                if (board[i, jw] != int.MaxValue)
                {
                    isWinnerVertically = false;
                }
            }

            return isWinnerHorizontally || isWinnerVertically;
        }
    }
}