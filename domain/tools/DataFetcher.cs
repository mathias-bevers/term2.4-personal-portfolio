namespace domain;

public static class DataFetcher
{
    public static string[] DataAsLines(this IDay day, string input, IDay.InputMode inputMode)
    {
        if (inputMode == IDay.InputMode.File)
        {
            string filePath = Path.Join(input, day.GetType().Name.FormatToFileName());
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"could not find the input file for: {filePath}");
            }

            input = File.ReadAllText(filePath);
        }

        return input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
    }

    public static string[] DataAsChunks(this IDay day, string input, IDay.InputMode inputMode)
    {
        if (inputMode == IDay.InputMode.File)
        {
            string filePath = Path.Join(input, day.GetType().Name.FormatToFileName());
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"could not find the input file for: {filePath}");
            }

            input = File.ReadAllText(filePath);
        }

        return input.Split([Environment.NewLine + Environment.NewLine], StringSplitOptions.RemoveEmptyEntries);
    }

    private static string FormatToFileName(this string dayName)
    {
        string[] parts = dayName.Split("_");
        return string.Concat(parts[1].PadLeft(2, '0'), '-', parts[2][^2..], ".txt");
    }
}