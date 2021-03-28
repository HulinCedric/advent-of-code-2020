using Xunit;

namespace AdventOfCode.Day11
{
    public class SeatingSystem
    {
        [Theory]
        [InlineData(SeatLayoutDescription.Example, 37)]
        // [InputFileData("Day11input.txt", ?)]
        public void Count_seats_occupied(
            string seatLayoutDescription,
            int expectedSeatsOccupiedCount)
        {
            // Given

            // When

            // Then
            Assert.Equal(expectedSeatsOccupiedCount, expectedSeatsOccupiedCount);
        }
    }
}