using AdventOfCode.Day12.NavigationInstructions;
using AdventOfCode.Day12.Ships;
using Xunit;

namespace AdventOfCode.Day12
{
    public class RainRisk
    {
        [Theory]
        [InlineData(NavigationInstructionsDescription.Example, 25)]
        [InputFileData("Day12/input.txt", 1133)]
        public void Determine_Manhattan_distance_between_ships_starting_position_and_instructions_location(
            string navigationInstructionsDescription,
            int expectedManhattanDistance)
        {
            // Given
            var navigationInstructions = NavigationInstructionsParser.Parse(navigationInstructionsDescription);
            var ship = new ShipWithDirection(Direction.East, 0, 0);

            // When
            foreach (var navigationInstruction in navigationInstructions)
                ship.Navigate(navigationInstruction);

            var actualManhattanDistance = ship.GetManhattanDistance();

            // Then
            Assert.Equal(expectedManhattanDistance, actualManhattanDistance);
        }
    }
}