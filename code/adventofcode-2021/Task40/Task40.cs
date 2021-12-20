using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adventofcode_2021.Task40
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/20/ task
        /// </summary>
        public static int Function((string alghoritm, List<string> image) input)
        {

            foreach (var item in input.image)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Input");

            var image = new List<string>(input.image);
            List<string> resultImage = new();

            (int x, int y) size = (image[0].Length, image.Count);
            var nonVisibleVal = ".";

            for (int c = 0; c < 50; c++)
            {
                resultImage = new();
                for (int i = 0; i < size.y; i++)
                {
                    var sb = new StringBuilder(image[i]);
                    for (int j = 0; j < size.x; j++)
                    {
                        var neighbors = GetNeighbors((j, i));
                        var neighborsStr = neighbors.Aggregate(string.Empty, (acc, item) =>
                        {
                            if (item.x >= 0 && item.x < size.x && item.y >= 0 && item.y < size.y)
                            {
                                acc += image[item.y][item.x].ToString();
                            }
                            else
                            {
                                acc += nonVisibleVal;
                            }
                            return acc;
                        });

                        var enhance = GetEnhance(neighborsStr, input.alghoritm);
                        sb[j] = enhance;
                    }

                    resultImage.Add(sb.ToString());
                }

                image = new List<string>(resultImage);
                nonVisibleVal = nonVisibleVal == "." ? input.alghoritm[0].ToString() : input.alghoritm[511].ToString();

                foreach (var item in resultImage)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("After step");
            }

            return resultImage.Sum(item => item.Count(c => c == '#'));
        }

        private static char GetEnhance(string neighborsVal, string alghoritm)
        {
            var binaryVal = neighborsVal.Replace("#", "1");
            binaryVal = binaryVal.Replace(".", "0");
            var b = alghoritm[Convert.ToInt32(binaryVal, 2)];
            return b;
        }

        private static List<(int x, int y)> GetNeighbors(
            (int x, int y) point) =>
            new List<(int i, int y)>
            {
                (point.x - 1, point.y - 1),
                (point.x, point.y - 1),
                (point.x + 1, point.y - 1),
                (point.x - 1, point.y),
                (point.x, point.y),
                (point.x + 1, point.y),
                (point.x - 1, point.y + 1),
                (point.x, point.y + 1),
                (point.x + 1, point.y + 1),

            }
            .ToList();
    }
}