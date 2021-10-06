using System;
using Dojo.Rooms;
using Shouldly;
using Xunit;

namespace Dojo.Tests
{
    public class BalancedTests
    {
        private readonly Balanced sut = new Balanced();

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

            result.ShouldBe(expectedResult);
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

            result.ShouldBe(expectedResult);
        }
    }
}
