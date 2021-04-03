using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AdventOfCode.Day11
{
    public class SeatingSystem
    {
        [Theory]
        [InlineData(SeatLayoutDescription.Example, 37)]
        [InputFileData("Day11/input.txt", 2277)]
        public void Count_seats_occupied_when_people_stop_moving(
            string seatLayoutDescription,
            int expectedSeatsOccupiedCount)
        {
            // Given
            const int peopleTolerance = 4;
            var seatLayout = SeatLayoutParser.Parse(seatLayoutDescription);

            // When
            var allocationSimulation = new SeatAllocationSimulator(peopleTolerance).SimulateAllocation(seatLayout);
            var actualSeatsOccupiedCount = allocationSimulation.CountOccupiedSeats();

            // Then
            Assert.Equal(expectedSeatsOccupiedCount, actualSeatsOccupiedCount);
        }
    }

    public class SeatAllocationSimulator
    {
        private readonly int peopleTolerance;

        public SeatAllocationSimulator(int peopleTolerance)
            => this.peopleTolerance = peopleTolerance;

        public SeatLayout SimulateAllocation(SeatLayout initialSeatLayout)
        {
            var seatLayout = initialSeatLayout;
            var nextSeatLayoutSimulation = seatLayout;

            // When
            do
            {
                seatLayout = nextSeatLayoutSimulation;
                nextSeatLayoutSimulation = seatLayout.NextRound(peopleTolerance);
            } while (nextSeatLayoutSimulation != seatLayout);

            return seatLayout;
        }
    }

    public class SeatLayout
    {
        private readonly int layoutMaxColumnIndex;
        private readonly int layoutMaxRowIndex;
        private readonly int layoutMinColumnIndex = 0;
        private readonly int layoutMinRowIndex = 0;
        private readonly string[] seatLayout;

        public SeatLayout(string[] seatLayout)
        {
            this.seatLayout = seatLayout;
            layoutMaxRowIndex = seatLayout.Length - 1;
            layoutMaxColumnIndex = seatLayout.First().Length - 1;
        }

        public int CountOccupiedSeats()
            => string.Join('\n', seatLayout)
                .Count(seat => seat == '#');

        private IEnumerable<char> GetAdjacentSeatsDescriptionForSeat(
            int centralSeatRowIndex,
            int centralSeatColumnIndex)
        {
            for (var seatRowIndex = centralSeatRowIndex - 1; seatRowIndex <= centralSeatRowIndex + 1; seatRowIndex++)
            for (var seatColumnIndex = centralSeatColumnIndex - 1;
                seatColumnIndex <= centralSeatColumnIndex + 1;
                seatColumnIndex++)
                if (seatRowIndex >= layoutMinRowIndex &&
                    seatRowIndex <= layoutMaxRowIndex &&
                    seatColumnIndex >= layoutMinColumnIndex &&
                    seatColumnIndex <= layoutMaxColumnIndex &&
                    !(seatRowIndex == centralSeatRowIndex && seatColumnIndex == centralSeatColumnIndex))
                    yield return seatLayout[seatRowIndex][seatColumnIndex];
        }

        public SeatLayout NextRound(int peopleTolerance)
        {
            var nextRoundSeatLayout = new string[seatLayout.Length];
            for (var rowIndex = 0; rowIndex < seatLayout.Length; rowIndex++)
            {
                var seatRow = seatLayout[rowIndex];
                var seatRowBuilder = new StringBuilder();
                for (var columnIndex = 0; columnIndex < seatRow.Length; columnIndex++)
                {
                    var seat = seatRow[columnIndex];
                    var adjacentSeats = GetAdjacentSeatsDescriptionForSeat(rowIndex, columnIndex);
                    var newSeat = seat switch
                    {
                        'L' when adjacentSeats.All(s => s != '#') => '#',
                        '#' when adjacentSeats.Count(s => s == '#') >= peopleTolerance => 'L',
                        _ => seat
                    };

                    seatRowBuilder.Append(newSeat);
                }

                nextRoundSeatLayout[rowIndex] = seatRowBuilder.ToString();
            }

            return new SeatLayout(nextRoundSeatLayout);
        }

        private bool Equals(SeatLayout other)
            => seatLayout.Zip(other.seatLayout)
                .All(
                    seatsElementsToCompare
                        => string.Equals(
                            seatsElementsToCompare.First,
                            seatsElementsToCompare.Second,
                            StringComparison.OrdinalIgnoreCase));

        public override bool Equals(object obj)
            => obj?.GetType() == GetType() && Equals((SeatLayout) obj);

        public override int GetHashCode()
            => seatLayout != null ? seatLayout.GetHashCode() : 0;

        public static bool operator ==(SeatLayout left, SeatLayout right)
            => Equals(left, right);

        public static bool operator !=(SeatLayout left, SeatLayout right)
            => !Equals(left, right);
    }

    public static class SeatLayoutParser
    {
        public static SeatLayout Parse(string seatLayoutDescription)
            => new(seatLayoutDescription.Split("\n"));
    }
}