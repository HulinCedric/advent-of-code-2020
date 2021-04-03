using System.Collections.Generic;

namespace AdventOfCode.Day11.AdjacentSeatsFinderStrategy
{
    public interface IAdjacentSeatsFinder
    {
        IEnumerable<char> GetAdjacentSeatsDescriptionForSeat(
            string[] seatLayoutDescription,
            int centralSeatRowIndex,
            int centralSeatColumnIndex);
    }
}