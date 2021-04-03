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
        [InlineData(SeatLayoutDescription.Example, 4, typeof(ImmediatelyAdjacentSeatsFinder), 37)]
        [InlineData(SeatLayoutDescription.Example, 5, typeof(FirstEncounteredAdjacentSeatsFinder), 26)]
        [InputFileData("Day11/input.txt", 4, typeof(ImmediatelyAdjacentSeatsFinder), 2277)]
        [InputFileData("Day11/input.txt", 5, typeof(FirstEncounteredAdjacentSeatsFinder), 2066)]
        public void Count_seats_occupied_when_people_stop_moving(
            string seatLayoutDescription,
            int peopleTolerance,
            Type adjacentSeatsFinderStrategyType,
            int expectedSeatsOccupiedCount)
        {
            // Given
            var adjacentSeatsFinderStrategy =
                Activator.CreateInstance(adjacentSeatsFinderStrategyType) as IAdjacentSeatsFinder;
            var seatLayout = SeatLayoutParser.Parse(seatLayoutDescription);

            // When
            var allocationSimulation =
                new SeatAllocationSimulator(peopleTolerance, adjacentSeatsFinderStrategy)
                    .SimulateAllocation(seatLayout);
            var actualSeatsOccupiedCount = allocationSimulation.CountOccupiedSeats();

            // Then
            Assert.Equal(expectedSeatsOccupiedCount, actualSeatsOccupiedCount);
        }
    }

    public class SeatAllocationSimulator
    {
        private readonly IAdjacentSeatsFinder adjacentSeatsFinderStrategy;
        private readonly int peopleTolerance;

        public SeatAllocationSimulator(
            int peopleTolerance,
            IAdjacentSeatsFinder adjacentSeatsFinderStrategy)
        {
            this.peopleTolerance = peopleTolerance;
            this.adjacentSeatsFinderStrategy = adjacentSeatsFinderStrategy;
        }

        public SeatLayout SimulateAllocation(SeatLayout initialSeatLayout)
        {
            var seatLayout = initialSeatLayout;
            var nextSeatLayoutSimulation = seatLayout;

            // When
            do
            {
                seatLayout = nextSeatLayoutSimulation;
                nextSeatLayoutSimulation = seatLayout.NextRound(peopleTolerance, adjacentSeatsFinderStrategy);
            } while (nextSeatLayoutSimulation != seatLayout);

            return seatLayout;
        }
    }

    public interface IAdjacentSeatsFinder
    {
        IEnumerable<char> GetAdjacentSeatsDescriptionForSeat(
            string[] seatLayoutDescription,
            int centralSeatRowIndex,
            int centralSeatColumnIndex);
    }

    internal class ImmediatelyAdjacentSeatsFinder : IAdjacentSeatsFinder
    {
        public IEnumerable<char> GetAdjacentSeatsDescriptionForSeat(
            string[] seatLayoutDescription,
            int centralSeatRowIndex,
            int centralSeatColumnIndex)
        {
            var layoutMaxColumnIndex = seatLayoutDescription[0].Length - 1;
            var layoutMaxRowIndex = seatLayoutDescription.Length - 1;
            var layoutMinColumnIndex = 0;
            var layoutMinRowIndex = 0;

            for (var seatRowIndex = centralSeatRowIndex - 1; seatRowIndex <= centralSeatRowIndex + 1; seatRowIndex++)
            for (var seatColumnIndex = centralSeatColumnIndex - 1;
                seatColumnIndex <= centralSeatColumnIndex + 1;
                seatColumnIndex++)
                if (seatRowIndex >= layoutMinRowIndex &&
                    seatRowIndex <= layoutMaxRowIndex &&
                    seatColumnIndex >= layoutMinColumnIndex &&
                    seatColumnIndex <= layoutMaxColumnIndex &&
                    !(seatRowIndex == centralSeatRowIndex && seatColumnIndex == centralSeatColumnIndex))
                    yield return seatLayoutDescription[seatRowIndex][seatColumnIndex];
        }
    }

    internal static class Directions
    {
        private static readonly (int, int) Up = (-1, 0);
        private static readonly (int, int) Down = (1, 0);
        private static readonly (int, int) Left = (0, -1);
        private static readonly (int, int) Right = (0, 1);
        private static readonly (int, int) UpRight = (-1, 1);
        private static readonly (int, int) DownRight = (1, 1);
        private static readonly (int, int) UpLeft = (-1, -1);
        private static readonly (int, int) DownLeft = (1, -1);

        internal static readonly (int, int)[] All =
        {
            Up, Down, Left, Right, UpRight, DownRight, UpLeft, DownLeft
        };
    }

    internal class FirstEncounteredAdjacentSeatsFinder : IAdjacentSeatsFinder
    {
        public IEnumerable<char> GetAdjacentSeatsDescriptionForSeat(
            string[] seatLayoutDescription,
            int centralSeatRowIndex,
            int centralSeatColumnIndex)
            => from direction in Directions.All
                select FirstSeatInDirection(
                    seatLayoutDescription,
                    centralSeatRowIndex,
                    centralSeatColumnIndex,
                    direction)
                into potentialSeat
                where potentialSeat != null
                select potentialSeat.Value;

        private static char? FirstSeatInDirection(
            IReadOnlyList<string> seatLayoutDescription,
            int centralSeatRowIndex,
            int centralSeatColumnIndex,
            (int rowDirection, int columnDirection) direction)

        {
            var layoutMaxColumnIndex = seatLayoutDescription[0].Length - 1;
            var layoutMaxRowIndex = seatLayoutDescription.Count - 1;
            var layoutMinColumnIndex = 0;
            var layoutMinRowIndex = 0;

            var currentSeatCoords = (rowIndex: centralSeatRowIndex, columnIndex: centralSeatColumnIndex);
            do
            {
                currentSeatCoords = (
                    currentSeatCoords.rowIndex + direction.rowDirection,
                    currentSeatCoords.columnIndex + direction.columnDirection);

                if (currentSeatCoords.rowIndex < layoutMinRowIndex ||
                    currentSeatCoords.rowIndex > layoutMaxRowIndex ||
                    currentSeatCoords.columnIndex < layoutMinColumnIndex ||
                    currentSeatCoords.columnIndex > layoutMaxColumnIndex)
                    break;

                var currentSeatDescription =
                    seatLayoutDescription[currentSeatCoords.rowIndex][currentSeatCoords.columnIndex];
                if (currentSeatDescription != '.')
                    return currentSeatDescription;
            } while (true);

            return null;
        }
    }

    public class SeatLayout
    {
        private readonly string[] seatLayout;

        public SeatLayout(string[] seatLayout)
            => this.seatLayout = seatLayout;


        public int CountOccupiedSeats()
            => string.Join('\n', seatLayout)
                .Count(seat => seat == '#');

        public SeatLayout NextRound(int peopleTolerance, IAdjacentSeatsFinder adjacentSeatsFinder)
        {
            var nextRoundSeatLayout = new string[seatLayout.Length];
            for (var rowIndex = 0; rowIndex < seatLayout.Length; rowIndex++)
            {
                var seatRow = seatLayout[rowIndex];
                var seatRowBuilder = new StringBuilder();
                for (var columnIndex = 0; columnIndex < seatRow.Length; columnIndex++)
                {
                    var seat = seatRow[columnIndex];
                    var adjacentSeats = adjacentSeatsFinder.GetAdjacentSeatsDescriptionForSeat(
                        seatLayout,
                        rowIndex,
                        columnIndex);
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