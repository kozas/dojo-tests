using System;
using System.Collections.Generic;
using System.Linq;

namespace Dojo.Rooms
{
    public class Balanced
    {
        public bool IsBalanced(string expression)
        {
            var bracketPairs = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '<', '>' },
                { '{', '}' }
            };

            var counters = new List<Counter>
            {
                new Counter('(', ')'),
                new Counter('{', '}'),
                new Counter('[', ']'),
                new Counter('<', '>'),
            };

            return IsBalancedCounter3(expression, counters);
            //return IsBalancedCounter(expression);
            //return IsBalancedStack(expression, bracketPairs);
        }

        private bool IsBalancedCounter(string expression)
        {
            int parenthesesCounter = 0;
            int squareCounter = 0;
            int curlyCounter = 0;
            int angleCounter = 0;

            foreach(char c in expression)
            {
                if (c.ToString() == "(")
                {
                    parenthesesCounter += 1;
                }
                if (c.ToString() == "[")
                {
                    squareCounter += 1;
                }
                if (c.ToString() == "{")
                {
                    curlyCounter += 1;
                }
                if (c.ToString() == "<")
                {
                    angleCounter += 1;
                }

                if (c.ToString() == ")")
                {
                    parenthesesCounter -= 1;
                }
                if (c.ToString() == "]")
                {
                    squareCounter -= 1;
                }
                if (c.ToString() == "}")
                {
                    curlyCounter -= 1;
                }
                if (c.ToString() == ">")
                {
                    angleCounter -= 1;
                }

                if (parenthesesCounter < 0 || squareCounter < 0 || curlyCounter < 0 || angleCounter < 0)
                {
                    return false;
                }
            }

            return (parenthesesCounter == 0 && squareCounter == 0 && curlyCounter == 0 && angleCounter == 0);
        }

        #region CounterWithHelper

        private bool IsBalancedCounter2(string expression)
        {
            var parenthesesCounter = 0;
            var squareCounter = 0;
            var curlyCounter = 0;
            var angleCounter = 0;

            foreach (var c in expression)
            {
                UpdateCount((value) => parenthesesCounter += value, c, '(', ')');
                parenthesesCounter = UpdateCount(parenthesesCounter, c, '(', ')');
                squareCounter = UpdateCount(squareCounter, c, '[', ']');
                curlyCounter = UpdateCount(curlyCounter, c, '{', '}');
                angleCounter = UpdateCount(angleCounter, c, '<', '>');

                if (parenthesesCounter < 0 || squareCounter < 0 || curlyCounter < 0 || angleCounter < 0) return false;
            }

            return parenthesesCounter == 0 && squareCounter == 0 && curlyCounter == 0 && angleCounter == 0;
        }

        private static int UpdateCount(int counter, char character, char openingCharacter, char closingCharacter)
        {
            if (character == openingCharacter) counter++;
            if (character == closingCharacter) counter--;

            return counter;
        }

        private static void UpdateCount(Action<int> counter, char character, char openingCharacter, char closingCharacter)
        {
            if (character == openingCharacter)
            {
                counter(1);
            }

            if (character == closingCharacter)
            {
                counter(-1);
            }
        }

        #endregion

        #region CounterWithValueTypes

        private bool IsBalancedCounter3(string expression, List<Counter> counters)
        {
            foreach (char c in expression)
            {
                counters.ForEach(counter => counter.UpdateCount(c));

                if (counters.Any(counter => counter.IsInvalid))
                {
                    return false;
                }
            }

            return (counters.TrueForAll(counter => counter.IsBalanced));
        }

        private class Counter
        {
            public Counter(char opening, char closing)
            {
                this.opening = opening;
                this.closing = closing;
            }

            public bool IsInvalid => counter < 0;  
            public bool IsBalanced => counter == 0;  

            private int counter = 0;
            private readonly char opening;
            private readonly char closing;

            public void UpdateCount(char c)
            {
                if (c == opening)
                {
                    counter++;
                }

                if (c == closing)
                {
                    counter--;
                }
            }
        }

        #endregion

        #region Stack

        private bool IsBalancedStack(string expression, Dictionary<char, char> pairs)
        {
            var bracketStack = new Stack<char>();

            foreach (char c in expression)
            {
                var isRegularCharacter = !pairs.ContainsKey(c) && !pairs.ContainsValue(c);
                if (isRegularCharacter)
                {
                    continue;
                }

                var isOpeningBrace = pairs.ContainsKey(c);
                if (isOpeningBrace)
                {
                    bracketStack.Push(c);
                    continue;
                }

                var stackIsEmpty = bracketStack.Count == 0;
                if (stackIsEmpty)
                {
                    return false;
                }

                var pairDoesNotMatch = pairs[bracketStack.Pop()] != c;
                if (pairDoesNotMatch)
                {
                    return false;
                }
            }

            return bracketStack.Count == 0;
        }

        #endregion
    }
}