using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

namespace domain;

public class AdventOfCode
{
    public int runningDaysCount { get; private set; }
    public string workingDirectory { get; }

    private readonly IDay[] days;
    

    public AdventOfCode(string workingDirectory)
    {
        this.workingDirectory = workingDirectory;
        List<IDay> temp = [];

        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (!type.GetInterfaces().Contains(typeof(IDay))) { continue; }

            if (Activator.CreateInstance(type) is not IDay day)
            {
                throw new InvalidCastException($"Something went wrong with activating the {type.Name} class as a day");
            }

            temp.Add(day);
        }

        temp.Sort((a, b) => a.date.CompareTo(b.date));
        days = temp.ToArray();
        
        runningDaysCount = days.Length;
    }


    /// <summary>
    /// The <c>Run</c> method is used to run all the <see cref="IDay"/> instances in the 
    /// </summary>
    /// <param name="callBack"></param>
    public void Run(Action<DateTime, DayRecord>? callBack)
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

            if (ReferenceEquals(null, callBack)) { return; }
            
            callBack(day.date, new DayRecord(initTime, one, two));
        }
    }
}