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
        return data[0];
    }

    public string StarTwo()
    {
        return string.Empty;
    }
}