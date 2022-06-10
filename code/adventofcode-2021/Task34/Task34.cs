namespace adventofcode_2021.Task34
{
    public class Solution
    {
        /// <summary>
        /// Solution for the second https://adventofcode.com/2021/day/17/ task
        /// </summary>
        public static int Function((int start, int end) x, (int start, int end) y)
        {
            var res = 0;
            for (var vx = 0; vx < 1000; vx++)
            {
                for (var vy = -1000; vy < 1000; vy++)
                {
                    if (Simulate(x.start, x.end, y.start, y.end, vx, vy))
                    {
                        res++;
                    }

                }
            }

            return res;
        }

        private static bool Simulate(int minX, int maxX, int minY, int maxY, int vx, int vy)
        {
            var x = 0;
            var y = 0;

            while (x <= maxX && y >= minY)
            {
                if (x >= minX && y <= maxY)
                {
                    return true;
                }

                x += vx;
                y += vy;

                if (vx != 0)
                {
                    vx = vx < 0 ? (vx + 1) : (vx - 1);
                }
                vy--;
            }

            return false;
        }
    }
}