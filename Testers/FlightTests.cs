using Domain;
using Domain.Tests;
using FluentAssertions;

namespace Testers;

public class FlightTests
{
    [Fact]
    public void BookingReducesSeatCount()
    {
        Flight flight = new(seatCapacity: 3);
        flight.Book("example@test.com", 1);
        flight.RemainingSeatCount.Should().Be(2);
    }
}