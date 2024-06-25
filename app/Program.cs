using System.Text;
using domain;

internal static class Program
{
    private const int PADDING = 20;

    private static void Main(string[] args)
    {
        AdventOfCode aoc = new(args);
        aoc.Run(Directory.GetCurrentDirectory(), OnDayComplete);
    }

    private static void OnDayComplete(DateTime date, DayRecord result)
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append(new string('\u2014', PADDING * 4));
        stringBuilder.AppendLine(date.Date.ToString("dddd, dd-MMM-yyyy"));
    
        stringBuilder.Append("\u2605 1:".PadRight(PADDING / 2));
        stringBuilder.Append(result.one.answer.PadRight(PADDING));
        stringBuilder.Append("completed in:".PadRight(PADDING));
        stringBuilder.Append(result.one.completionTime);
        stringBuilder.AppendLine("ms");
    
        stringBuilder.Append("\u2605 2:".PadRight(PADDING / 2));
        stringBuilder.Append(result.two.answer.PadRight(PADDING));
        stringBuilder.Append("completed in:".PadRight(PADDING));
        stringBuilder.Append(result.two.completionTime);
        stringBuilder.AppendLine("ms");

        stringBuilder.AppendLine();
        Console.WriteLine(stringBuilder.ToString());
    }
}
