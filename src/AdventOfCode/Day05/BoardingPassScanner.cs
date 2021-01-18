using System.Linq;

namespace AdventOfCode.Day05
{
    public static class BoardingPassScanner
    {
        public static int GetHighestSeatId(string boardingPassesDescription)
            => BoardingPassParser
            .ParseBoardingPassesToSeatIds(boardingPassesDescription)
            .Max();
    }
}