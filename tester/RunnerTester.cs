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
        AdventOfCode aoc = new(["--year", "2023"]);

        // Then
        aoc.runningDaysCount.Should().Be(1);
    }

    [Fact]
    public void RunAOC()
    {
        // Given
        AdventOfCode aoc = new(["-a"]);

        // When

        // Then
        aoc.Run(Directory.GetCurrentDirectory(), null);
    }

    [Fact]
    public void InitializeWrongDate()
    {
        Action act = () => { AdventOfCode aoc = new(["-y", "2025", "-d", "2"]); };
        act.Should().Throw<NullReferenceException>();
    }
}