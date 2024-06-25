using System.Diagnostics;
using System.Reflection;
using CommandLine;

namespace domain;

public class AdventOfCode
{
    public int runningDaysCount { get; private set; }
    public string workingDirectory { get; private set; } = string.Empty;

    private readonly IDay[] days;
    private readonly Options options;


    public AdventOfCode(string[] args)
    {
        options = Parser.Default.ParseArguments<Options>(args).Value;

        if (options.today) { days = [GetDay(DateTime.Today)]; }
        else if (options.day > 0) { days = [GetDay(new DateTime(options.year, 12, options.day))]; }
        else { days = GetDayRange(options.all, options.year).ToArray(); }

        runningDaysCount = days.Length;
    }


    /// <summary>
    ///     The <c>Run</c> method is used to run all the <see cref="IDay" /> instances in the days collection.
    /// </summary>
    /// <param name="workingDirectory">The directory where the program is currently being executed.</param>
    /// <param name="callBack">
    ///     A callback function which needs to be executed when a day has been finished. Can be <c>null</c>
    /// </param>
    public void Run(string workingDirectory, Action<DateTime, DayRecord>? callBack)
    {
        if (days.Length < 1) { return; }

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

    private static List<IDay> GetDayRange(bool all, int year)
    {
        List<IDay> temp = [];

        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (!type.GetInterfaces().Contains(typeof(IDay))) { continue; }

            if (Activator.CreateInstance(type) is not IDay day)
            {
                throw new InvalidCastException($"Something went wrong with activating the {type.Name} class as a day");
            }

            if (!all && year != day.date.Year) { continue; }

            temp.Add(day);
        }

        if (temp.Count < 1) { throw new NullReferenceException($"Could not find any days for year: {year}"); }


        temp.Sort((a, b) => a.date.CompareTo(b.date));
        return temp;
    }

    private static IDay GetDay(DateTime date)
    {
        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
        {
            if (!type.GetInterfaces().Contains(typeof(IDay))) { continue; }

            if (Activator.CreateInstance(type) is not IDay day)
            {
                throw new InvalidCastException($"Something went wrong with activating the {type.Name} class as a day");
            }

            if (day.date == date) { return day; }
        }

        throw new NullReferenceException($"Could not find a day for date: {date:dd-MMM-yyyy}");
    }

    public class Options
    {
        [Option('a', "all", HelpText = "Run all days in the project")]
        public bool all { get; set; } = false;

        [Option('t', "today", HelpText = "Run only the today's parts")]
        public bool today { get; set; } = false;

        [Option('d', "day", HelpText = "Run a specific day, if year is not set from this year.")]
        public int day { get; set; } = 0;

        [Option('y', "year", HelpText = "Specify a specific year to run, when not specified only this year is ran")]
        public int year { get; set; } = DateTime.Now.Year;
    }
}