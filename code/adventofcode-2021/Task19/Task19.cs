using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task19
{
    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/10/ task
        /// </summary>
        public static int Function(List<List<char>> input)
        {
            var closingScored = new Dictionary<char, int>
            { [')'] = 3, [']'] = 57, ['}'] = 1197, ['>'] = 25137 };
            Stack<char> openingBrackets = new();
            var result = 0;

            input.ForEach(line => line.ForEach(character =>
            {
                if (!closingScored.ContainsKey(character))
                {
                    openingBrackets.Push(character);
                }
                else
                {
                    var lastOpening = openingBrackets.Pop();
                    result += (lastOpening, character) switch
                    {
                        ('[', ']') or ('{', '}') or ('(', ')') or ('<', '>') => 0,
                        _ => closingScored[character]
                    };
                }
            }));

            return result;
        }
    }
}