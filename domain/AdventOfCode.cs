using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

namespace domain;

public class AdventOfCode
{
    public int runningDaysCount { get; private set; }
    public string workingDirectory { get; }

    private readonly List<IDay> days;
    

    public AdventOfCode(string workingDirectory)
    {
        this.workingDirectory = workingDirectory;
        days = new List<IDay>();

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


    public IEnumerable<(DateTime, DayRecord)> Run()
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

            yield return (day.date, new DayRecord(initTime, one, two));
        }
    }
}