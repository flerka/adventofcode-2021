using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task9
{
    public record struct Point(int x, int y);

    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/5/ task
        /// </summary>
        public static int Function(List<(Point start, Point end)> data)
        {
            var boardSize = 1000;
            var board = new int[boardSize][];
            foreach (var pointPair in data)
            {
                // filter invalid points
                if (pointPair.start.x > pointPair.end.x
                    || pointPair.start.y > pointPair.end.y
                    || (pointPair.start.x < pointPair.end.x
                        && pointPair.start.y < pointPair.end.y))
                {
                    continue;
                }

                if (pointPair.start.x < pointPair.end.x)
                {
                    for (var i = pointPair.start.x; i <= pointPair.end.x; i++)
                    {
                        if (board[i] == null) { board[i] = new int[boardSize]; }
                        board[i][pointPair.start.y]++;
                    }
                }
                else
                {
                    for (var i = pointPair.start.y; i <= pointPair.end.y; i++)
                    {
                        if (board[pointPair.start.x] == null) { board[pointPair.start.x] = new int[boardSize]; }
                        board[pointPair.start.x][i]++;
                    }
                }

            }

            return board.Where(item => item != null).Sum(item => item.Count(item2 => item2 >= 2));
        }
    }
}