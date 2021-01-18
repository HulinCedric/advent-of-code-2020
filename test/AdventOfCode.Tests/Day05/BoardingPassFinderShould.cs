using Xunit;

namespace AdventOfCode.Day05.Tests
{
    public class BoardingPassFinderShould
    {
        [Theory]
        [InlineData("FF\nBF", 1)]
        [InlineData("BFF\nFBF", 3)]
        public void Find_the_only_missing_seat_id_in_full_flight_boarding_passes(
             string boardingPassesDescription,
             int expectedAvailableSeatId)
        {
            //When
            var availableSeatId = BoardingPassFinder.FindAvailableSeatId(boardingPassesDescription);

            //Then
            Assert.Equal(expectedAvailableSeatId, availableSeatId);
        }

        [Fact]
        public void Find_the_only_missing_seat_id_in_full_flight_boarding_passes_for_problem()
        {
            //Given
            var boardingPassesDescription = BoardingPassDescription.ProblemDescription;
            var expectedAvailableSeatId = 517;

            //When
            var availableSeatId = BoardingPassFinder.FindAvailableSeatId(boardingPassesDescription);

            //Then
            Assert.Equal(expectedAvailableSeatId, availableSeatId);
        }
    }
}