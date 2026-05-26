using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorLibrary.Tests.Unit;

public class HomeClass
{
    private readonly Calculator _calculator = new();


    [Theory]
    [InlineData(5,5,10)]
    [InlineData(-5,5,0)]
    [InlineData(-15,-5,-20)]
    public void Added_ShouldAddTwoNumbers_WhenTwoNumbersAreIntegers(int a ,int b,int expected)
    {
        var result = _calculator.Add(a, b);
        //Assert.Equal(expected, result);
        //üsttekinin yerine fluentassertiion kullanılaiblir

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(5,-5,10)]
    [InlineData(15,-5,20)]
    [InlineData(-5,-5,0)]
    [InlineData(-15,-5,-10)]
    [InlineData(5,-10,15)]
    public void Subtract_ShouldSubtractTwoNumbers_WhenTwoNumbersAreIntegers(int a ,int b,int expected)
    {
        var result = _calculator.Subtract(a, b);
        //Assert.Equal(expected, result);

        //üsttekinin yerine fluentassertiion kullanılaiblir

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(5, 5, 25)]
    [InlineData(50, 0, 0)]
    [InlineData(-5, 5, -25)]
    public void Multiply_ShouldMultiplyTwoNumbers_WhenTwoNumbersAreIntegers(int a, int b, int expected)
    {
        var result = _calculator.Multiply(a, b);
        //Assert.Equal(expected, result);
        //üsttekinin yerine fluentassertiion kullanılaiblir

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(5, 5, 1)]
    [InlineData(15, 5, 3)]
    [InlineData(0, 0, 0, Skip ="Bu Test ignore edilmiştir")]
    public void Divide_ShouldDivideTwoNumbers_WhenTwoNumbersAreIntegers(int a, int b, int expected)
    {
        var result = _calculator.Divide(a, b);
        //Assert.Equal(expected, result);

        //üsttekinin yerine fluentassertiion kullanılaiblir

        result.Should().Be(expected);
    }


}
