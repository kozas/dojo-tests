using Dojo.Rooms;
using System;
using System.Linq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Dojo.Tests
{
    public class FavoriteAnimalTests : TestBase
    {
        private readonly FavoriteAnimal sut = new();

        public FavoriteAnimalTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData('b', "You chose Bird")]
        [InlineData('B', "You chose Bird")]    
        [InlineData('c', "You chose Cat")]
        [InlineData('C', "You chose Cat")]
        [InlineData('d', "You chose Dog")]
        [InlineData('D', "You chose Dog")]
        [InlineData(' ', "Please choose Bird (b), Cat (c) or Dog (d)")]
        [InlineData('a', "Please choose Bird (b), Cat (c) or Dog (d)")]
        [InlineData('m', "Please choose Bird (b), Cat (c) or Dog (d)")]
        [InlineData('p', "Please choose Bird (b), Cat (c) or Dog (d)")]
        public void MakeChoice(char choice, string expectedResult)
        {
            var result = sut.MakeChoice(choice);

            result.ShouldBe(expectedResult, result);
        }
    }
}
