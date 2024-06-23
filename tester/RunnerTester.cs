using domain;
using FluentAssertions;

namespace tester;

public class RunnerTester
{
    [Fact]
    public void InitializeAOC()
    {
        // Given
        string currentDirectory = Directory.GetCurrentDirectory();
        
        // When
        AdventOfCode aoc = new(currentDirectory);
        
        // Then
        aoc.workingDirectory.Should().Be(currentDirectory);
        aoc.runningDaysCount.Should().Be(1);
    }

    [Fact]
    public void RunAOC()
    {
        // Given
        string currentDirectory = Directory.GetCurrentDirectory();
        
        AdventOfCode aoc = new(currentDirectory);
        
        // When
        
        // Then
        aoc.Run(null);
    }
}