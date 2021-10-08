using System;
using System.Collections.Generic;
using System.Text;

namespace Dojo.Rooms
{
    public class ReverseString
    {
        public string Reverse(string expression)
        {
            //return ReverseWithString(expression);
            //return ReverseWithArray(expression);
            return ReverseWithStack(expression);
        }

        private string ReverseWithString(string expression)
        {
            var stringBuilder = new StringBuilder();

            foreach (char c in expression)
            {
                stringBuilder.Insert(0, c);
            }

            return stringBuilder.ToString();
        }

        private string ReverseWithArray(string expression)
        {
            var array = expression.ToCharArray();
            var reversedArray = new Char[array.Length];
            var lastIndex = array.Length - 1;

            for (int i = 0; i <= lastIndex; i++)
            {
                reversedArray[i] = array[lastIndex - i];
            }

            return new string(reversedArray);
        }

        private string ReverseWithStack(string expression)
        {
            var stack = new Stack<char>(expression.Length);

            foreach (char c in expression)
            {
                stack.Push(c);
            }

            return new string(stack.ToArray());
        }
    }
}
