using Xunit;

namespace AdventOfCode.Day05.Tests
{

    public class BoardingPassParserShould
    {
        [Theory]
        [InlineData("F\nB", new int[] { 0, 1 })]
        public void Parse_boarding_passes_to_seat_ids(
            string boardingPassesDescription,
            int[] expectedSeatIds)
        {
            //When
            var seatIds = BoardingPassParser.ParseBoardingPassesToSeatIds(boardingPassesDescription);

            //Then
            Assert.Equal(expectedSeatIds, seatIds);
        }
    }
}