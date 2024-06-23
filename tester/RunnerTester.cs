using domain;
using FluentAssertions;

namespace tester;

public class RunnerTester
{
    [Fact]
    public void InitializeAOC()
    {
        // Given
        
        // When
        AdventOfCode aoc = new(new string[]{ "--year", "2023"});
        
        // Then
        aoc.runningDaysCount.Should().Be(1);
    }

    [Fact]
    public void RunAOC()
    {
        // Given
        AdventOfCode aoc = new([]);
        
        // When
        
        // Then
        aoc.Run(Directory.GetCurrentDirectory(), null);
    }
}