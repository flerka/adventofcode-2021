using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode_2021.Task35
{
    public class Number
    {
        public int? NumberValue { get; set; }

        public bool? IsRightChild
        {
            get
            {
                if (Parent == null)
                {
                    return null;
                }

                return Parent.RightChild == this;
            }
        }

        public bool? IsLeftChild
        {
            get
            {
                if (Parent == null)
                {
                    return null;
                }

                return Parent.LeftChild == this;
            }
        }

        public int Depth
        {
            get
            {
                var currentP = this.Parent;
                // root depth is 1
                var count = 0;
                while (currentP != null)
                {
                    count++;
                    currentP = currentP.Parent;
                }
                return count;
            }
        }

        /// <summary>
        /// String representation of the tree. For root only.
        /// </summary>
        public override string ToString()
        {
            if (this.NumberValue.HasValue)
            {
                return this.NumberValue.Value.ToString();
            }

            return $"[{this.LeftChild},{this.RightChild}]";
        }

        public int ToMagnitude()
        {
            if (this.NumberValue.HasValue)
            {
                return this.NumberValue.Value;
            }

            return (3 * this.LeftChild.ToMagnitude()) + 2 * (this.RightChild.ToMagnitude());

        }

        public Number LeftChild { get; set; }
        public Number RightChild { get; set; }
        public Number Parent { get; set; }

    }

    public class Solution
    {
        /// <summary>
        /// Solution for the first https://adventofcode.com/2021/day/18/ task
        /// </summary>
        public static int Function(IEnumerable<string> input)
        {
            List<Number> acc = null;
            foreach (var item in input)
            {
                var numbers = ParseNumbers(item);
                acc = acc == null ? numbers : Reduce(Sum(acc, numbers));
            }

            Console.WriteLine($"Final result - {acc[0].ToString()}");
            Console.WriteLine($"Final magnitude - {acc[0].ToMagnitude()}");
            return acc[0].ToMagnitude();
        }

        public static List<Number> Sum(List<Number> first, List<Number> second)
        {
            var result = new List<Number>();
            var newRoot = new Number
            {
                LeftChild = first.First(),
                RightChild = second.First(),
            };
            newRoot.LeftChild.Parent = newRoot;
            newRoot.RightChild.Parent = newRoot;
            result.Add(newRoot);
            result.AddRange(first);
            result.AddRange(second);

            return result;
        }

        private static List<Number> Reduce(List<Number> input)
        {
            var numbers = input;
            while (true)
            {
                var explodeRes = ExplodeIfNeeded(numbers);
                numbers = explodeRes.numbers;
                if (explodeRes.isExploded)
                {
                    //Console.WriteLine("Exploded");
                }
                if (!explodeRes.isExploded)
                {
                    var splitRes = SplitIfNeeded(numbers);
                    numbers = splitRes.numbers;
                    if (splitRes.isSplited)
                    {
                        //Console.WriteLine("Exploded");
                    }

                    if (!splitRes.isSplited)
                    {
                        break;
                    }
                }
            }

            return numbers;
        }

        private static (List<Number> numbers, bool isSplited) SplitIfNeeded(List<Number> numbers)
        {
            if (numbers.Count(item => item.NumberValue.HasValue && item.NumberValue > 9) == 0)
            {
                return (numbers, false);
            }

            var numberToSplit = FindLeftmostAbove9(numbers[0]);
            var leftChild = new Number
            {
                Parent = numberToSplit,
                NumberValue = numberToSplit.NumberValue / 2
            };
            numberToSplit.LeftChild = leftChild;

            var rightChild = new Number
            {
                Parent = numberToSplit,
                NumberValue = numberToSplit.NumberValue - leftChild.NumberValue
            };
            numberToSplit.RightChild = rightChild;

            numberToSplit.NumberValue = null;
            var result = new List<Number>(numbers);
            result.Add(leftChild);
            result.Add(rightChild);


            Console.WriteLine($"split:{result[0].ToString()}");
            return (result, true);
        }

        private static (List<Number> numbers, bool isExploded) ExplodeIfNeeded(List<Number> numbers)
        {

            var number = FindLeftmostWithDepth(numbers[0]);
            if (number == null)
            {
                return (numbers, false);
            }

            PropagateLeft(number);
            PropagateRight(number);
            // remove info about us
            var newList = numbers.Where(item => item != number.LeftChild && item != number.RightChild).ToList();
            number.NumberValue = 0;
            number.RightChild = null;
            number.LeftChild = null;

            Console.WriteLine($"exploded:{newList[0].ToString()}");
            return (newList, true);
        }

        private static void PropagateLeft(Number value)
        {
            var ancestors = new List<Number>();
            ancestors.Add(value);

            var next = value.Parent;
            Number subtreeToFindRightest = null;
            while (next != null && subtreeToFindRightest == null)
            {
                var found = ancestors.FirstOrDefault(item => item == next.LeftChild);
                if (found != null)
                {
                    ancestors.Add(next);
                    next = next.Parent;
                    continue;
                }

                subtreeToFindRightest = next.LeftChild;
            }

            if (subtreeToFindRightest == null)
            {
                return;
            }

            Number rightmost = FindRightmostVal(subtreeToFindRightest);
            if (rightmost != null)
            {
                rightmost.NumberValue += value.LeftChild.NumberValue;
            }
        }

        private static void PropagateRight(Number value)
        {
            var ancestors = new List<Number>();
            ancestors.Add(value);

            var next = value.Parent;
            Number subtreeToFindLeftest = null;
            while (next != null && subtreeToFindLeftest == null)
            {
                var found = ancestors.FirstOrDefault(item => item == next.RightChild);
                if (found != null)
                {
                    ancestors.Add(next);
                    next = next.Parent;
                    continue;
                }

                subtreeToFindLeftest = next.RightChild;
            }

            if (subtreeToFindLeftest == null)
            {
                return;
            }

            Number leftMost = FindLeftmostVal(subtreeToFindLeftest);
            if (leftMost != null)
            {
                leftMost.NumberValue += value.RightChild.NumberValue;
            }
        }

        private static Number FindRightmostVal(Number root)
        {
            var s = new Stack<Number>();
            s.Push(root);

            var results = new Stack<Number>();

            while (s.Any())
            {
                var entry = s.Pop();
                if (entry.NumberValue.HasValue)
                {
                    results.Push(entry);
                    continue;
                }

                if (entry.RightChild != null)
                {
                    s.Push(entry.RightChild);
                }

                if (entry.LeftChild != null)
                {
                    s.Push(entry.LeftChild);
                }
            }

            if (results.Any())
            {
                var res = results.Pop();
                if (!res.NumberValue.HasValue)
                {
                    throw new Exception("should be numeric");
                }

                return res;
            }

            return null;
        }

        private static Number FindLeftmostVal(Number root)
        {
            var s = new Stack<Number>();
            s.Push(root);

            var results = new Stack<Number>();

            while (s.Any())
            {
                var entry = s.Pop();
                if (entry.NumberValue.HasValue)
                {
                    results.Push(entry);
                    continue;
                }

                if (entry.LeftChild != null)
                {
                    s.Push(entry.LeftChild);
                }

                if (entry.RightChild != null)
                {
                    s.Push(entry.RightChild);
                }
            }

            if (results.Any())
            {
                var res = results.Pop();
                if (!res.NumberValue.HasValue)
                {
                    throw new Exception("should be numeric");
                }

                return res;
            }

            return null;
        }

        private static Number FindLeftmostAbove9(Number root)
        {
            var s = new Stack<Number>();
            s.Push(root);

            var results = new Stack<Number>();

            while (s.Any())
            {
                var entry = s.Pop();
                if (entry.NumberValue.HasValue)
                {
                    if (entry.NumberValue > 9)
                    {
                        results.Push(entry);
                    }
                    continue;
                }

                if (entry.LeftChild != null)
                {
                    s.Push(entry.LeftChild);
                }

                if (entry.RightChild != null)
                {
                    s.Push(entry.RightChild);
                }
            }

            if (results.Any())
            {
                var res = results.Pop();
                if (!res.NumberValue.HasValue)
                {
                    throw new Exception("should be numeric");
                }

                return res;
            }

            return null;
        }

        private static Number FindLeftmostWithDepth(Number root)
        {
            var s = new Stack<Number>();
            s.Push(root);

            var results = new Stack<Number>();

            while (s.Any())
            {
                var entry = s.Pop();
                if (entry.RightChild != null && entry.LeftChild != null)
                {
                    if (entry.Depth >= 4)
                    {
                        results.Push(entry);
                    }
                }

                if (entry.LeftChild != null)
                {
                    s.Push(entry.LeftChild);
                }

                if (entry.RightChild != null)
                {
                    s.Push(entry.RightChild);
                }
            }

            if (results.Any())
            {
                var res = results.Pop();
                return res;
            }

            return null;
        }

        private static List<Number> ParseNumbers(string input)
        {
            List<Number> result = new();
            Stack<Number> parents = new();

            bool theNextIsRight = false;

            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == '[')
                {
                    var item = new Number
                    {
                        Parent = parents.Count > 0 ? parents.Peek() : null,
                    };
                    if (parents.Count > 0)
                    {
                        if (theNextIsRight) { parents.Peek().RightChild = item; }
                        else { parents.Peek().LeftChild = item; }
                    }

                    result.Add(item);
                    parents.Push(item);
                    theNextIsRight = false;
                }

                if (input[i] == ']')
                {
                    parents.Pop();

                }

                if (input[i] == ',') { theNextIsRight = true; }

                if (Char.IsNumber(input[i]))
                {
                    var stringNum = input[i].ToString();

                    // check if next char in number
                    if (Char.IsNumber(input[i + 1]))
                    {
                        stringNum += input[i + 1].ToString();
                        // skip next element
                        i++;
                    }

                    var item = new Number
                    {
                        Parent = parents.Peek(),
                        NumberValue = int.Parse(stringNum)
                    };
                    result.Add(item);
                    if (theNextIsRight) { parents.Peek().RightChild = item; }
                    else { parents.Peek().LeftChild = item; }

                }
            }

            return result;
        }
    }
}