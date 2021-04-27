using Xunit;

namespace AdventOfCode.Day05
{
    public class BoardingPassScannerShould
    {
        [Theory]
        [InlineData("F\nB", 1)]
        [InputFileData("Day05/input.txt", 832)]
        public void Get_highest_seat_id(
            string boardingPassesDescription,
            int expectedHighestSeatId)
        {
            //When
            var highestSeatId = BoardingPassScanner.GetHighestSeatId(boardingPassesDescription);

            //Then
            Assert.Equal(expectedHighestSeatId, highestSeatId);
        }
    }
}