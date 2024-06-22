namespace domain;

public interface IDay
{
    /// <summary>
    /// The date of when the puzzle has been published on the <see href="https://adventofcode.com/">aoc-site</see>.
    /// Args are formated: <c>(yyyy, m, d)</c>. 
    /// </summary>
    public DateTime date { get; }

    /// <summary>
    /// This method will be called before the stars. In this method the input file should be parsed to a usable state.
    /// </summary>
    /// <param name="fileDirectory">The directory where the data is expected.</param>
    void Initialize(string fileDirectory);

    /// <summary>
    /// Algorithm to solve the first star of the day's puzzle.
    /// </summary>
    /// <returns>the answer created by the algorithm</returns>
    string StarOne();

    /// <summary>
    /// Algorithm to solve the second star of the day's puzzle.
    /// </summary>
    /// <returns>the answer created by the algorithm</returns>
    string StarTwo();
}