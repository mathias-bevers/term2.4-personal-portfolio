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
        return string.Empty;
    }
}