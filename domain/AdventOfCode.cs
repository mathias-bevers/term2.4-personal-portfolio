using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using CommandLine;

namespace domain;

public class AdventOfCode
{
    public class Options
    {
        [Option('y', "year", HelpText = "Specify a specific year to run, when not specified only this year is ran")]
        public int year { get; private set; } = DateTime.Now.Year;
    }
    
    public string workingDirectory { get; private set; } = string.Empty;
    
    public int runningDaysCount { get; private set; }

    private readonly Options options;
    private readonly IDay[] days;


    public AdventOfCode(string[] args)
    {
        options = Parser.Default.ParseArguments<Options>(args).Value;
        
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
    /// The <c>Run</c> method is used to run all the <see cref="IDay"/> instances in the days collection. 
    /// </summary>
    /// <param name="workingDirectory">The directory where the program is currently being executed.</param>
    /// <param name="callBack">
    /// A callback function which needs to be executed when a day has been finished. Can be <c>null</c>
    /// </param>
    public void Run(string workingDirectory, Action<DateTime, DayRecord>? callBack)
    {
        Stopwatch stopwatch = new();
        this.workingDirectory = workingDirectory;
        string inputDirectory = Path.Join(this.workingDirectory, "inputs");

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