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
    public class UberPoolTests : TestBase
    {
        /*
        Summary
            You are given a two-dimensional integer list requested_trips containing [start_x, end_x, num_passengers], 
            and an integer capacity. Each requested trip asks to pick up num_passengers passenger at start_x and drop them off at end_x. 
            You also have a car with the given capacity, and start at x = 0.
            
            Given that you'd like to pick up every passenger and can only move right, 
            return whether you can pick up and drop off everyone.

        Input
            trips = [
                [1, 30, 2],
                [3, 5, 3],
                [5, 9, 3]
                    ]
            capacity = 6
        Output
            True
         */

        private readonly UberPool sut = new();

        public UberPoolTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(new[] { 1, 30, 2, 3, 5, 3, 5, 9, 3 }, 6, true)]
        [InlineData(new[] { 1, 30, 2, 3, 30, 3, 5, 9, 1 }, 6, true)]
        [InlineData(new[] { 0, 30, 10 }, 10, true)]
        [InlineData(new[] { 0, 30, 10,30, 31, 5 }, 10, true)]
        [InlineData(new[] { 1, 30, 2, 3, 6, 3, 5, 9, 3 }, 8, true)]
        [InlineData(new[] { 0, 30, 10 }, 6, false)]
        [InlineData(new[] { 1, 30, 2, 3, 6, 3, 5, 9, 3 }, 6, false)]
        public void Process(int[] trips, int capacity, bool expectedResult)
        {
            var multiDimensionalArray = trips.ToMultiDimensionalArray(3);

            var result = sut.Process(trips: multiDimensionalArray, capacity: capacity);

            result.ShouldBe(expectedResult);
        }
    }
}