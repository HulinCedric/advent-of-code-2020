using Xunit;

namespace AdventOfCode.Day05.Tests
{
    public class SeatIdDecoderShould
    {
        [Theory]
        [InlineData("FBFBBFFRLR", 357)]
        [InlineData("BFFFBBFRRR", 567)]
        [InlineData("FFFBBBFRRR", 119)]
        [InlineData("BBFFBBFRLL", 820)]
        public void Decode_seat_description_to_seat_id(
            string seatDescription,
            int expectedSeatId)
        {
            //When
            var seatId = SeatIdDecoder.Decode(seatDescription);

            //Then
            Assert.Equal(expectedSeatId, seatId);
        }
    }
}