namespace Domain;

public class Flight(int seatCapacity)
{
    public int RemainingSeatCount { get; private set; } = seatCapacity;

    public void Book(string v1, int v2)
    {
        RemainingSeatCount -= v2;
    }
}