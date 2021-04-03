namespace AdventOfCode.Day11
{
    public static class SeatLayoutParser
    {
        public static SeatLayout Parse(string seatLayoutDescription)
            => new(seatLayoutDescription.Split("\n"));
    }
}