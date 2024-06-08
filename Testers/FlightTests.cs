using Domain;
using FluentAssertions;

namespace Testers;

public class FlightTests
{
    [Fact]
    public void BookingReducesSeatCount()
    {
        // Given
        Flight flight = new(seatCapacity: 3);     
        
        // When
        flight.Book("passenger@example.com", 1);         
        
        // Then
        flight.remainingSeatCount.Should().Be(2);  
    }

    [Fact]
    public void AvoidOverbooking()
    {
        // Given
        Flight flight = new(seatCapacity: 3);
        
        // When
        object? error = flight.Book("passenger@example.com", 4);

        // Then
        error.Should().BeOfType<OverbookingError>();
    }

    [Fact]
    public void AvoidInvalidEmail()
    {
        // Given
        Flight flight = new(seatCapacity: 3);

        // When 
        object? error = flight.Book("this is not an email address", 1);

        // Then
        error.Should().BeOfType<InvalidEmailError>();
    }
}