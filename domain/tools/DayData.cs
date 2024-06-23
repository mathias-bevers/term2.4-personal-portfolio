namespace domain;

public readonly struct DayRecord(long initializeTime, DayRecord.StarRecord one, DayRecord.StarRecord two)
{
    public long initializeTime { get; } = initializeTime;
    public StarRecord one { get; } = one;
    public StarRecord two { get; } = two;
    
    public readonly struct StarRecord(long completionTime, string answer)
    {
        public string answer { get; } = answer;
        public long completionTime { get; } = completionTime;
    }
}

