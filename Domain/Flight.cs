namespace Domain;

public class Flight(int seatCapacity)
{
    public int remainingSeatCount { get; private set; } = seatCapacity;

    public void Book(string passengerEmail, int seatCount)
    {
        remainingSeatCount -= seatCount;
    }
}