using System.Linq;

namespace AdventOfCode.Day05
{
    public static class BoardingPassFinder
    {
        public static int FindAvailableSeatId(string boardingPassesDescription)
        {
            var bookeadSeatIds = BoardingPassParser.ParseBoardingPassesToSeatIds(boardingPassesDescription);
            var allSeatIds = Enumerable.Range(bookeadSeatIds.Min(), bookeadSeatIds.Count());
            return allSeatIds.Except(bookeadSeatIds).Single();
        }
    }
}