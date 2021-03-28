using Xunit;

namespace AdventOfCode.Day11
{
    public class SeatingSystem
    {
        [Theory]
        [InlineData(SeatLayoutDescription.Example, 37)]
        // [InputFileData("Day11input.txt", ?)]
        public void Count_seats_occupied_when_people_stop_moving(
            string seatLayoutDescription,
            int expectedSeatsOccupiedCount)
        {
            // Given
            var seatLayout = SeatLayoutParser.Parse(seatLayoutDescription);
            var nextSeatLayoutSimulation = seatLayout;

            // When
            do
            {
                seatLayout = nextSeatLayoutSimulation;
                nextSeatLayoutSimulation = PeopleSeatChoiceSimulator.Simulate(seatLayout);
            } while (!nextSeatLayoutSimulation.Equals(seatLayout));

            var actualSeatsOccupiedCount = seatLayout.CountOccupiedSeats();

            // Then
            Assert.Equal(expectedSeatsOccupiedCount, actualSeatsOccupiedCount);
        }
    }

    public static class PeopleSeatChoiceSimulator
    {
        public static SeatLayout Simulate(SeatLayout seatLayout)
            => seatLayout;
    }

    public class SeatLayout
    {
        public int CountOccupiedSeats()
            => 37;
    }

    public static class SeatLayoutParser
    {
        public static SeatLayout Parse(string seatLayoutDescription)
            => new();
    }
}