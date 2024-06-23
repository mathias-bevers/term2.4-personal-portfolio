namespace domain;

public static class DataFetcher
{
    public static string[] AsLines(this IDay day, string directory)
    {
        string filePath = Path.Join(directory, day.FormatToFileName());

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"could not find file: {filePath}");
        }

        return File.ReadAllLines(filePath);
    }

    private static string FormatToFileName(this IDay day)
    {
        string[] parts = day.GetType().Name.Split("_");
        return string.Concat(parts[1].PadLeft(2, '0'), '-', parts[2][^2..], ".txt");
    }
}