namespace domain;

public class Day_1_2023 : IDay
{
    public DateTime date => new(2023, 12, 1);
    private string[] data = [];

    public void Initialize(string fileDirectory)
    {
        data = this.AsLines(fileDirectory);
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
        return string.Empty;
    }
}