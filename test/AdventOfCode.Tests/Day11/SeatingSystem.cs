using System;
using AdventOfCode.Day11.AdjacentSeatsFinderStrategy;
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
            var adjacentSeatsFinderStrategy = InstantiateAdjacentSeatsFinderStrategy(adjacentSeatsFinderStrategyType);
            var seatLayout = SeatLayoutParser.Parse(seatLayoutDescription);
            var seatAllocationSimulator = new SeatAllocationSimulator(peopleTolerance, adjacentSeatsFinderStrategy);

            // When
            var allocationSimulation = seatAllocationSimulator.SimulateAllocation(seatLayout);
            var actualSeatsOccupiedCount = allocationSimulation.CountOccupiedSeats();

            // Then
            Assert.Equal(expectedSeatsOccupiedCount, actualSeatsOccupiedCount);
        }

        private static IAdjacentSeatsFinder InstantiateAdjacentSeatsFinderStrategy(Type adjacentSeatsFinderStrategyType)
            => Activator.CreateInstance(adjacentSeatsFinderStrategyType) is IAdjacentSeatsFinder
                adjacentSeatsFinderStrategy ?
                adjacentSeatsFinderStrategy :
                throw new ArgumentNullException(nameof(adjacentSeatsFinderStrategy));
    }
}