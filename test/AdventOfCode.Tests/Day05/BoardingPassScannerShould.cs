using Xunit;

namespace AdventOfCode.Day05.Tests
{
    public class BoardingPassScannerShould
    {
        [Theory]
        [InlineData("F\nB", 1)]
        public void Get_highest_seat_id(
            string boardingPassesDescription,
            int expectedHighestSeatId)
        {
            //When
            var highestSeatId = BoardingPassScanner.GetHighestSeatId(boardingPassesDescription);

            //Then
            Assert.Equal(expectedHighestSeatId, highestSeatId);
        }

        [Fact]
        public void Get_highest_seat_id_for_problem()
        {
            //Given
            var boardingPassesDescription = BoardingPassDescription.ProblemDescription;
            var expectedHighestSeatId = 832;

            //When
            var highestSeatId = BoardingPassScanner.GetHighestSeatId(boardingPassesDescription);

            //Then
            Assert.Equal(expectedHighestSeatId, highestSeatId);
        }
    }
}