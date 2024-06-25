using domain;
using FluentAssertions;

namespace tester;

public class Tests_2022
{
    [Fact]
    public void TestD1()
    {
        // Given
        Day_1_2022 day = new ();
        const string input = "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000\n";

        // When
        day.Initialize(input, IDay.InputMode.Text);

        // Then
        day.StarOne().Should().Be("24000");
        day.StarTwo().Should().Be("45000");
    }
}