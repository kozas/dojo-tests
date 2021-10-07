using Dojo.Rooms;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace Dojo.Tests
{
    public class BalancedTests : TestBase
    {
        private readonly Balanced sut = new();

        public BalancedTests(ITestOutputHelper output) : base (output)
        {
        }

        [Theory]
        [InlineData("(a + b - c)))", false)]
        [InlineData("(((a + b) - c)))", false)]
        [InlineData("(a + b - c", false)]
        [InlineData("a + b - c)", false)]
        [InlineData("(a + b)) - c", false)]
        [InlineData("(a + b()( - c", false)]
        [InlineData("a + )b( - c", false)]
        [InlineData("(a + )b( - c)", true)]
        [InlineData("(a) + (b)( - c)", true)]
        [InlineData("((a + )b( - c))", true)]
        [InlineData("a + b - c", true)]
        [InlineData("(a) + b - c", true)]
        [InlineData("((((a + )b)))( - c)", true)]
        public void SingleBraceType_IsBalanced(string expression, bool expectedResult)
        {
            var result = sut.IsBalanced(expression);

            result.ShouldBe(expectedResult, expression);
        }

        [Theory]
        [InlineData("<(a + b - c)))>", false)]
        [InlineData("[](((a + b) - c)))", false)]
        [InlineData("{(a + b - c}", false)]
        [InlineData("a + b - c>", false)]
        [InlineData("(a + b)} - c", false)]
        [InlineData("(a + b()< - c", false)]
        [InlineData("a + )b[ - c", false)]
        [InlineData("<(a + )b[( - c)]>", true)]
        [InlineData("{[(a)]} + (b)( - c)", true)]
        [InlineData("({(a + )b( - c)})", true)]
        [InlineData("a + b - c[]{}<>()", true)]
        [InlineData("{(a) + b} - [c]", true)]
        [InlineData("((({(a + )}b)))( - [c])", true)]
        public void MultipleBraceTypes_IsBalanced(string expression, bool expectedResult)
        {
            var result = sut.IsBalanced(expression);

            result.ShouldBe(expectedResult, expression);
        }
    }
}
