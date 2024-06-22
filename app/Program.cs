using System.Text;
using System.Text.Json;
using domain;

const int PADDING = 20;

string currentDirectory = Directory.GetCurrentDirectory();
AdventOfCode aoc = new(currentDirectory);
aoc.Run();

string outputFile = Path.Join(currentDirectory, "output.json");
string jsonText = File.ReadAllText(outputFile);
if (!File.Exists(outputFile))
{
    Console.WriteLine($"ERR: could not find the file: {outputFile}");
    return;
}

Dictionary<DateTime, DayRecord>? results = JsonSerializer.Deserialize<Dictionary<DateTime, DayRecord>>(jsonText);

if (ReferenceEquals(null, results) || results.Values.Count < 1)
{
    Console.WriteLine($"ERR: no (valid) entries in the output file: {outputFile}");
    return;
}

StringBuilder stringBuilder = new();
foreach ((DateTime date, DayRecord record) in results)
{
    stringBuilder.Append(new string('\u2014', PADDING * 4));
    stringBuilder.AppendLine(date.Date.ToString("dddd, dd-MMM-yyyy"));


    string answer = string.IsNullOrEmpty(record.one.answer) ? "null" : record.one.answer;
    stringBuilder.Append("\u2605 1:".PadRight(PADDING / 2));
    stringBuilder.Append(answer.PadRight(PADDING));
    stringBuilder.Append("completed in:".PadRight(PADDING));
    stringBuilder.Append(record.one.completionTime);
    stringBuilder.AppendLine("ms");
    
    answer = string.IsNullOrEmpty(record.two.answer) ? "null" : record.two.answer;
    stringBuilder.Append("\u2605 2:".PadRight(PADDING / 2));
    stringBuilder.Append(answer.PadRight(PADDING));
    stringBuilder.Append("completed in:".PadRight(PADDING));
    stringBuilder.Append(record.two.completionTime);
    stringBuilder.AppendLine("ms");

    stringBuilder.AppendLine();
}

Console.WriteLine(stringBuilder.ToString());