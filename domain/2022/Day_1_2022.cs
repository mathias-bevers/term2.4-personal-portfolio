namespace domain;

public class Day_1_2022 : IDay
{
    private string[] data;
    public DateTime date => new(2022, 12, 1);


    public void Initialize(string input, IDay.InputMode mode = IDay.InputMode.File)
    {
        data = this.DataAsChunks(input, mode);
    }

    public string StarOne()
    {
        return data.Select(chunk => chunk.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
            .Sum(int.Parse)).Max().ToString();
    }

    public string StarTwo()
    {
        int[] highest = new int[3];

        foreach (string chunk in data)
        {
            int sum = chunk.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Sum(int.Parse);
            
            int index = -1;
            for (int i = highest.Length - 1; i >= 0; --i)
            {
                if (sum <= highest[i]) { break; }

                index = i;
            }

            if (index < 0) { continue; }

            Utils.InsertItem(ref highest, index, sum);
        }

        return highest.Sum().ToString();
    }
}