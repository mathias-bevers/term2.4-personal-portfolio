using domain;
using FluentAssertions;

namespace tester;

public class Test_2023
{
    [Fact]
    public void TestD1()
    {
        // Given
        Day_1_2023 day = new();
        string inputPath = Path.Join(Directory.GetCurrentDirectory(), "inputs");
        
        // When    
        day.Initialize(inputPath);
        
        // Then
        day.StarOne().Should().Be("142");
        day.StarTwo().Should().Be("281");
    }
}