using Domain;
using FluentAssertions;

namespace Testers;

public class FlightTests
{
    [Fact]
    public void BookingReducesSeatCount()
    {
        Flight flight = new(seatCapacity: 3);       // Given
        flight.Book("example@test.com", 1);         // When
        flight.remainingSeatCount.Should().Be(2);   // Then
    }
}