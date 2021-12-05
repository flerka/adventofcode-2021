using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task10
{
    public record struct Point(int x, int y);

    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/5/ task
        /// </summary>
        public static int Function(List<(Point start, Point end)> data)
        {
            var boardSize = 1000;
            var board = new int[boardSize][];
            foreach (var pointPair in data)
            {   // filter invalid points
                if (pointPair.start.x > pointPair.end.x
                    || pointPair.start.y > pointPair.end.y
                    || (pointPair.start.x < pointPair.end.x
                        && pointPair.start.y < pointPair.end.y))
                {
                    PerformAngled(pointPair, board, boardSize);
                    continue;
                }

                if (pointPair.start.x < pointPair.end.x)
                {
                    PerformHorizontal(pointPair, board, boardSize);
                }
                else
                {
                    PerformVertical(pointPair, board, boardSize);
                }

            }

            return board.Where(item => item != null).Sum(item => item.Count(item2 => item2 >= 2));
        }

        private static void PerformHorizontal((Point start, Point end) pointPair, int [][] board, int boardSize)
        {
            for (var i = pointPair.start.x; i <= pointPair.end.x; i++)
            {
                if (board[i] == null) { board[i] = new int[boardSize]; }
                board[i][pointPair.start.y]++;
            }
        }

        private static void PerformVertical((Point start, Point end) pointPair, int[][] board, int boardSize)
        {
            for (var i = pointPair.start.y; i <= pointPair.end.y; i++)
            {
                if (board[pointPair.start.x] == null) { board[pointPair.start.x] = new int[boardSize]; }
                board[pointPair.start.x][i]++;
            }
        }
        private static void PerformAngled((Point start, Point end) pointPair, int[][] board, int boardSize)
        {
            if (pointPair.end.x > pointPair.start.x && pointPair.end.y > pointPair.start.y)
            {
                for (int i = pointPair.start.x, j = pointPair.start.y; i <= pointPair.end.x; i++, j++)
                {
                    if (board[i] == null) { board[i] = new int[boardSize]; }
                    board[i][j]++;
                }
            }
            if (pointPair.end.x > pointPair.start.x && pointPair.end.y < pointPair.start.y) 
            {
                for (int i = pointPair.start.x, j = pointPair.start.y; i <= pointPair.end.x; i++, j--)
                {
                    if (board[i] == null) { board[i] = new int[boardSize]; }
                    board[i][j]++;
                }
            }
            if (pointPair.end.x < pointPair.start.x && pointPair.end.y > pointPair.start.y) 
            {
                for (int i = pointPair.start.x, j = pointPair.start.y; i >= pointPair.end.x; i--, j++)
                {
                    if (board[i] == null) { board[i] = new int[boardSize]; }
                    board[i][j]++;
                }
            }
            if (pointPair.end.x < pointPair.start.x && pointPair.end.y < pointPair.start.y)
            {
                for (int i = pointPair.start.x, j = pointPair.start.y; i >= pointPair.end.x; i--, j--)
                {
                    if (board[i] == null) { board[i] = new int[boardSize]; }
                    board[i][j]++;
                }
            }
        }
    }
}