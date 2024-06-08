using System;
using Xunit;
using Domain;

namespace CalculatorTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Calculator calculator = new();
        if (calculator.Sum(2, 2) != 4) { throw new Exception(); }
    }
}