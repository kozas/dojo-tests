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
    public class RangeUpdateTests : TestBase
    {
        /*
        Summary
            You are given a list of integers nums and a two-dimensional list of integers operations.
            Each operation is of the following form: [L, R, X], which means that you should increment by X
            all the elements from indices L to R inclusive in the list (the list is 0-indexed).
            Apply all operations and return the final list.

         Example
             numbers = [7, 3, 1, -10, 3]
              operations = [
                             [0, 0, 3],
                             [1, 3, 2],
                             [2, 3, 5]
                             ]
        
         Output 
            [10, 5, 8, -3, 3]
        
        Explanation
            The initial list is [7, 3, 1, -10, 3].

            After applying the first operation ([0, 0, 3]) the list becomes [10, 3, 1, -10, 3].
            After applying the second operation ([1, 3, 2]) the list becomes [10, 5, 3, -8, 3].
            After applying the third operation ([2, 3, 5]) the list becomes [10, 5, 8, -3, 3].
         */

        private readonly RangeUpdate sut = new RangeUpdate();

        public RangeUpdateTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(new int[]{7,3,1,-10,3}, new int[]{ 0, 0, 3, 1, 3, 2, 2, 3, 5 }, new int[]{ 10, 5, 8, -3, 3 })]
        public void RangeUpdate(int[] numbers, int[] operations, int[] expectedResult)
        {
            var multiDimensionalArray = operations.ToMultiDimensionalArray(3);

            //int[] result = sut.Process(numbers: numbers, operations: multiDimensionalArray);

            //result.ShouldBe(expectedResult);
        }
    }
}
