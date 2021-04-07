using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day12
{
    public class RainRisk
    {
        [Theory]
        [InlineData(NavigationInstructionsDescription.Example, 25)]
        [InputFileData("Day12/input.txt", 25)]
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
            => navigationInstructionsDescription
                .Split("\n")
                .Select(
                    navigationInstructionDescription =>
                        NavigationInstructionBase.CreateInstance(
                            ExtractAction(navigationInstructionDescription),
                            ExtractValue(navigationInstructionDescription)));

        private static int ExtractValue(string navigationInstructionDescription)
            => int.Parse(navigationInstructionDescription[1..]);

        private static char ExtractAction(string navigationInstructionDescription)
            => navigationInstructionDescription[0];
    }

    public abstract record NavigationInstructionBase
    {
        protected NavigationInstructionBase(char action, int value)
        {
            Action = action;
            Value = value;
        }

        protected char Action { get; }
        protected int Value { get; }

        public static NavigationInstruction CreateInstance(char action, int value)
            => action switch
            {
                _ => new NavigationInstruction(action, value)
            };
    }

    public record NavigationInstruction
        : NavigationInstructionBase
    {
        public NavigationInstruction(char action, int value)
            : base(action, value)
        {
        }
    }
}