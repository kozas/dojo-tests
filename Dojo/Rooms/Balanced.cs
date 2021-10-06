using System;
using System.Collections.Generic;
using System.Linq;

namespace Dojo.Rooms
{
    public class Balanced
    {
        public bool IsBalanced(string expression)
        {
            //return IsBalancedWithCounter(expression);
            //return IsBalancedWithValueCounters(expression, counters);
            return IsBalancedWithStack(expression, pairs);
        }

        #region With Counter

        private bool IsBalancedWithCounter(string expression)
        {
            var parenthesesCount = 0;
            var squareBraceCount = 0;
            var angleBracketCount = 0;
            var curlyBraceCount = 0;

            foreach (var character in expression)
            {
                UpdateCount(ref parenthesesCount, character, '(', ')');
                UpdateCount(ref squareBraceCount, character, '[', ']');
                UpdateCount(ref angleBracketCount, character, '<', '>');
                UpdateCount(ref curlyBraceCount, character, '{', '}');

                if (parenthesesCount < 0 ||
                    squareBraceCount < 0 ||
                    angleBracketCount < 0 ||
                    curlyBraceCount < 0
                )
                {
                    return false;
                }
            }

            return parenthesesCount == 0 &&
                   squareBraceCount == 0 &&
                   angleBracketCount == 0 &&
                   curlyBraceCount == 0;
        }

        private void UpdateCount(ref int counter, char character, char open, char close)
        {
            if (character == open)
            {
                counter++;
            }

            if (character == close)
            {
                counter--;
            }
        }

        #endregion

        #region With Value Counters

        private readonly List<Counter> counters = new List<Counter>
        {
            new Counter('(', ')'),
            new Counter('[', ']'),
            new Counter('{', '}'),
            new Counter('<', '>')
        };

        private class Counter
        {
            private readonly char open;
            private readonly char close;
            private int counter;

            public bool IsValid => counter >= 0;
            public bool IsInvalid => !IsValid;
            public bool IsBalanced => counter == 0;

            public Counter(char open, char close)
            {
                this.open = open;
                this.close = close;
            }

            public void UpdateCounter(char character)
            {
                if (character == open)
                {
                    counter++;
                }

                if (character == close)
                {
                    counter--;
                }
            }
        }

        private bool IsBalancedWithValueCounters(string expression, List<Counter> counters)
        {
            foreach (var character in expression)
            {
                counters.ForEach(counter => counter.UpdateCounter(character));

                if (counters.Any(counter => counter.IsInvalid))
                {
                    return false;
                }
            }

            return counters.TrueForAll(counter => counter.IsBalanced);
        }

        #endregion

        #region With Stack

        private readonly Dictionary<char, char> pairs = new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' },
            { '<', '>' }
        };

        private bool IsBalancedWithStack(string expression, Dictionary<char, char> pairs)
        {
            var stack = new Stack<char>(expression.Length);

            foreach (var character in expression)
            {
                if (pairs.ContainsKey(character))
                {
                    stack.Push(character);
                }

                if (pairs.ContainsValue(character))
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    var key = stack.Pop();
                    if (pairs[key] != character)
                    {
                        return false;
                    }

                }

                Console.WriteLine(stack.ToString());
            }

            return stack.Count == 0;
        }

        #endregion
    }
}