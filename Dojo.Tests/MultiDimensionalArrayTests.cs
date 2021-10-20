using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dojo.Rooms;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Dojo.Tests
{
    public class MultiDimensionalArrayTests : TestBase
    {
        /*
        Summary
            You are given an array of numbers and a column count. Convert the array of numbers into a multi-dimensional array
        Input
            numbers = [1,2,3,4,5,6]
            columnCount = 2
        Output
            [[1,2],[3,4],[5,6]]
         */

        //private readonly MultiDimensionalArray sut = new();
        
        public MultiDimensionalArrayTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(new[] { 7, 3, 1, -10, 3, 2 }, 2)]
        [InlineData(new[] { 7, 3, 1, -10, 3, 2 }, 3)]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 4)]
        public void Process(int[] numbers, int columnCount)
        {
            //var result = sut.Process(numbers, columnCount);
            var rowCount = numbers.Length / columnCount;
            var valueIndex = 0;

            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    //result[rowIndex, columnIndex].ShouldBe(numbers[valueIndex]);
                    valueIndex++;
                }
            }
        }
    }
}
