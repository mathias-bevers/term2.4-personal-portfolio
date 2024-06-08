using FluentAssertions;
using Domain;

namespace CalculatorTest;

public class CalculatorTests
{
    [Fact] public void SumOf2And2ShouldBe4() => new Calculator().Sum(2, 2).Should().Be(4);
}