using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Tests
{
    public static class Extensions
    {
        public static int[,] ToMultiDimensionalArray(this int[] numbers, int columnCount)
        {
            var rowCount = numbers.Length / columnCount;
            var multiDimensionalArray = new int[rowCount, columnCount];
            var valueIndex = 0;

            for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    multiDimensionalArray[rowIndex, columnIndex] = numbers[valueIndex];
                    valueIndex++;
                }
            }

            return multiDimensionalArray;
        }
    }
}
