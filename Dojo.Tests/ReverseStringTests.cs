using Dojo.Rooms;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Dojo.Tests
{
    public class ReverseStringTests : TestBase
    {
        private readonly ReverseString sut = new();

        public ReverseStringTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        [InlineData("123456789", "987654321")]
        [InlineData("Hello", "olleH")]
        [InlineData("Hard work and training. There's no secret formula.", ".alumrof terces on s'erehT .gniniart dna krow draH")]
        public void SingleBraceType_IsBalanced(string expression, string expectedResult)
        {
            var result = sut.Reverse(expression);

            result.ShouldBe(expectedResult, expression);
        }
    }
}
