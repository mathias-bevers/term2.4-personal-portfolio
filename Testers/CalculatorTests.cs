using FluentAssertions;
using Domain.Tests;

namespace Testers;

public class CalculatorTests
{
    [Fact] public void SumOf3And3ShouldBe6() => new Calculator().Sum(3, 3).Should().Be(6);
    [Fact] public void ProductOf3And3ShouldBe9() => new Calculator().Product(3, 3).Should().Be(9);
}