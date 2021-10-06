using System;
using Dojo.Rooms;
using Shouldly;
using Xunit;

namespace Dojo.Tests
{
    public class BalancedTests
    {
        private Balanced sut = new Balanced();

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
        public void Easy_IsBalanced(string expression, bool expectedResult)
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
        public void Hard_IsBalanced(string expression, bool expectedResult)
        {
            var result = sut.IsBalanced(expression);

            result.ShouldBe(expectedResult);
        }
    }
}
