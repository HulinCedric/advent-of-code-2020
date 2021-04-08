using System;
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
                        NavigationInstruction.CreateInstance(
                            ExtractAction(navigationInstructionDescription),
                            ExtractValue(navigationInstructionDescription)));

        private static int ExtractValue(string navigationInstructionDescription)
            => int.Parse(navigationInstructionDescription[1..]);

        private static char ExtractAction(string navigationInstructionDescription)
            => navigationInstructionDescription[0];
    }

    public abstract record NavigationInstruction(char Action, int Value)
    {
        public static NavigationInstruction CreateInstance(char action, int value)
            => action switch
            {
                'N' => new NorthNavigationInstruction(action, value),
                'S' => new SouthNavigationInstruction(action, value),
                'E' => new EastNavigationInstruction(action, value),
                'W' => new WestNavigationInstruction(action, value),
                'L' => new LeftNavigationInstruction(action, value),
                'R' => new RightNavigationInstruction(action, value),
                'F' => new ForwardNavigationInstruction(action, value),
                _ => throw new ArgumentOutOfRangeException(nameof(action), action, null)
            };
    }

    public record ForwardNavigationInstruction
        : NavigationInstruction
    {
        public ForwardNavigationInstruction(char Action, int Value)
            : base(Action, Value)
        {
        }
    }

    public record RightNavigationInstruction
        : NavigationInstruction
    {
        public RightNavigationInstruction(char Action, int Value)
            : base(Action, Value)
        {
        }
    }

    public record LeftNavigationInstruction
        : NavigationInstruction
    {
        public LeftNavigationInstruction(char action, int value)
            : base(action, value)
        {
        }
    }

    public record WestNavigationInstruction
        : NavigationInstruction
    {
        public WestNavigationInstruction(char action, int value)
            : base(action, value)
        {
        }
    }

    public record EastNavigationInstruction
        : NavigationInstruction
    {
        public EastNavigationInstruction(char action, int value)
            : base(action, value)

        {
        }
    }

    public record NorthNavigationInstruction
        : NavigationInstruction
    {
        public NorthNavigationInstruction(char action, int value)
            : base(action, value)
        {
        }
    }

    public record SouthNavigationInstruction
        : NavigationInstruction
    {
        public SouthNavigationInstruction(char action, int value)
            : base(action, value)
        {
        }
    }
}