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
    /// <param name="input">This can be either the file path if <paramref name="isFile"/> is true.
    /// Or the text chunk if <paramref name="isFile"/> is false.</param>
    /// <param name="mode">Switch load from file or use the input as text.</param>
    void Initialize(string input, InputMode mode = InputMode.File);

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
    
    public enum InputMode { File, Text }
}