using System.Text.RegularExpressions;

namespace domain;

public class Day_1_2023 : IDay
{
    private string[] data = [];
    
    public DateTime date => new(2023, 12, 1);
    
    public void Initialize(string input, IDay.InputMode mode = IDay.InputMode.File)
    {
        data = this.DataAsLines(input, mode);
    }

    public string StarOne()
    {
        int sum = 0;

        foreach (string line in data)
        {
            string number = string.Empty;

            number += line.First(char.IsDigit);
            number += line.Last(char.IsDigit);
            
            sum += int.Parse(number);
        }

        return sum.ToString();
    }

    public string StarTwo()
    {
        Regex regex = new("[1-9]|one|two|three|four|five|six|seven|eight|nine");
        Dictionary<string, int> spelledOut = new()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

        int sum = 0;

        foreach (string line in data)
        {
            MatchCollection matches = regex.Matches(line);

            string first = matches.First().Value;
            if (first.Length > 1) { first = spelledOut[first].ToString(); }

            string last = matches.Last().Value;
            if (last.Length > 1) { last = spelledOut[last].ToString(); }

            sum += int.Parse(first + last);
        }

        return sum.ToString();
    }
}