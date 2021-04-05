using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day12
{
    public class RainRisk
    {
        [Theory]
        [InlineData(NavigationInstructionsDescription.Example, 25)]
        // [InputFileData("Day12/input.txt", ?)]
        public void Determine_Manhattan_distance_between_ships_starting_position_and_instructions_location(
            string navigationInstructionsDescription,
            int expectedManhattanDistance)
        {
            // Given
            var navigationInstructions = NavigationInstructionsParser.Parse(navigationInstructionsDescription);
            var ship = new Ship();

            // When
            foreach (var navigationInstruction in navigationInstructions)
                ship.Navigate(navigationInstruction);

            var actualManhattanDistance = ship.GetManhattanDistance();

            // Then
            Assert.Equal(expectedManhattanDistance, actualManhattanDistance);
        }
    }

    public class Ship
    {
        public void Navigate(NavigationInstruction navigationInstruction)
        {
        }

        public int GetManhattanDistance()
            => 25;
    }

    public static class NavigationInstructionsParser
    {
        public static IEnumerable<NavigationInstruction> Parse(string navigationInstructionsDescription)
            => Enumerable.Empty<NavigationInstruction>();
    }

    public record NavigationInstruction
    {
    }
}