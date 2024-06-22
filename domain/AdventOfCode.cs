using System.Reflection;

namespace domain;

public class AdventOfCode
{
    public int runningDaysCount { get; private set; }
    public string fileDirectory { get; private set; }
    
    private readonly List<IDay> days;
    
    //TODO: save output data to file 

    public AdventOfCode(string fileDirectory)
    {
        this.fileDirectory = fileDirectory;
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
        
        days.Sort((a,b) => a.date.CompareTo(b.date));
        runningDaysCount = days.Count;
    }


    public void Run()
    {
        foreach (IDay day in days)
        {
            day.Initialize(fileDirectory);

            string starOne = day.StarOne();
            string starTwo = day.StarTwo();
        }
    }
}