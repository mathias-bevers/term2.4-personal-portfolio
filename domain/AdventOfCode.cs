using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

namespace domain;

public class AdventOfCode
{
    public int runningDaysCount { get; private set; }
    public string workingDirectory { get; }

    private readonly List<IDay> days;

    private readonly Dictionary<DateTime, DayRecord> results;

    public AdventOfCode(string workingDirectory)
    {
        this.workingDirectory = workingDirectory;
        days = new List<IDay>();
        results = new Dictionary<DateTime, DayRecord>();

        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (!type.GetInterfaces().Contains(typeof(IDay))) { continue; }

            if (Activator.CreateInstance(type) is not IDay day)
            {
                throw new InvalidCastException($"Something went wrong with activating the {type.Name} class as a day");
            }

            days.Add(day);
        }

        days.Sort((a, b) => a.date.CompareTo(b.date));
        runningDaysCount = days.Count;
    }


    public void Run()
    {
        Stopwatch stopwatch = new();
        string inputDirectory = Path.Join(workingDirectory, "inputs");
        
        foreach (IDay day in days)
        {
            stopwatch.Restart();
            day.Initialize(inputDirectory);
            long initTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            string result = day.StarOne();
            DayRecord.StarRecord one = new(stopwatch.ElapsedMilliseconds, result);

            stopwatch.Restart();
            result = day.StarTwo();
            DayRecord.StarRecord two = new(stopwatch.ElapsedMilliseconds, result);

            results.Add(day.date, new DayRecord(initTime, one, two));
        }

        SaveResults();
    }

    private void SaveResults()
    {
        string outputFile = Path.Join(workingDirectory, "output.json");

        using FileStream fileStream = File.Create(outputFile);
        JsonSerializer.Serialize(fileStream, results);
    }
}