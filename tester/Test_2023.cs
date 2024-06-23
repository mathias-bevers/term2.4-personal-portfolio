using domain;
using FluentAssertions;

namespace tester;

public class Test_2023
{
    [Fact]
    public void TestD1()
    {
        // Given
        Day_1_2023 dayS1 = new();
        const string inputOne = "1abc2\npqr3stu8vwx\na1b2c3d4e5f\ntreb7uchet\n";
        Day_1_2023 dayS2 = new();
        const string inputTwo =
            "two1nine\neightwothree\nabcone2threexyz\nxtwone3four\n4nineeightseven2\nzoneight234\n7pqrstsixteen\n";
        
        // When    
        dayS1.Initialize(inputOne, IDay.InputMode.Text);
        dayS2.Initialize(inputTwo, IDay.InputMode.Text);
        
        // Then
        dayS1.StarOne().Should().Be("142");
        dayS1.StarTwo().Should().Be("281");
    }
}