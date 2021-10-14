using Dojo.Rooms;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Dojo.Tests
{
    /// <summary>
    /// Given a list of integers prices representing prices of cars for sale, and a budget,
    /// return the maximum number of cars you can buy.
    /// </summary>
    public class CarBrokerTests: TestBase
    {
        private readonly CarBroker sut = new();

        public CarBrokerTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(new int[]{ 900, 300, 200, 400, 900 }, 199, 0)]
        [InlineData(new int[]{ 90, 30, 20, 40, 90 }, 0, 0)]
        [InlineData(new int[]{ 190, 130, 210, 400, 90 }, 95, 1)]
        [InlineData(new int[]{ 90, 30, 20, 40, 90 }, 95, 3)]
        [InlineData(new int[]{ 90, 30, 20, 40, 90 }, 400, 5)]
        public void BuyingCars(int[] prices, int budget, int expectedResult)
        {
            var result = sut.GetPurchasedCarCount(prices: prices, budget: budget);

            result.ShouldBe(expectedResult);
        }
    }
}
