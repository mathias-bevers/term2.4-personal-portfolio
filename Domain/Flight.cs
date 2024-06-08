namespace Domain;

public class Flight(int seatCapacity)
{
    public int remainingSeatCount { get; private set; } = seatCapacity;

    public object? Book(string passengerEmail, int seatCount)
    {
        if (seatCount > remainingSeatCount) { return new OverbookingError(); }

        remainingSeatCount -= seatCount;
        return null;
    }
}