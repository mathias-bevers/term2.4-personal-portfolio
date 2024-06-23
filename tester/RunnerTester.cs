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
        string outputPath = Path.Join(currentDirectory, "output.json");
        
        AdventOfCode aoc = new(currentDirectory);
        
        // When
        aoc.Run();
        
        // Then
        File.Exists(outputPath).Should().BeTrue($"Cannot find a file at path: {outputPath}");
        File.ReadAllText(outputPath).Should().NotBeEmpty();
    }
}