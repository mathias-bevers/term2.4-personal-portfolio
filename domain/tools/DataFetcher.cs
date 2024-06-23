namespace domain;

public static class DataFetcher
{
    public static string[] DataAsLines(this IDay day, string input, IDay.InputMode inputMode)
    {
        if (inputMode == IDay.InputMode.File)
        {
            string filePath = Path.Join(input, day.FormatToFileName());
            if (!File.Exists(filePath)) { throw new FileNotFoundException($"could not find file: {filePath}"); }

            input = File.ReadAllText(filePath);
        }

        return input.Split(["\r\n", "\r", "\n"], StringSplitOptions.RemoveEmptyEntries);
    }

    private static string FormatToFileName(this IDay day)
    {
        string[] parts = day.GetType().Name.Split("_");
        return string.Concat(parts[1].PadLeft(2, '0'), '-', parts[2][^2..], ".txt");
    }
}