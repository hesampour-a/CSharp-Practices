using BasicUnitTest;
using FluentAssertions;
using JetBrains.Annotations;
using Xunit;

namespace BasicUnitTest.Tests;


public class CalculatorTest
{
    [Fact]
    public void TestCalculator()
    {
        //arrange
        int num1 = 2;
        int num2 = 3;

        //act
        var result = Calculator.Sum(num1, num2);

        //assertion

        result.Should().Be(num1 + num2);
    }
}