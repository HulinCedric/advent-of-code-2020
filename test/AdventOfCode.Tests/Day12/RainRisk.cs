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
        [InputFileData("Day12/input.txt", 1133)]
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
        private Direction direction;
        private int x;
        private int y;

        public Ship()
        {
            direction = Direction.East;
            y = 0;
            x = 0;
        }

        public void Navigate(NavigationInstruction navigationInstruction)
            => navigationInstruction.Execute(this);

        public int GetManhattanDistance()
            => Math.Abs(x) + Math.Abs(y);

        public void MoveForward(int unit)
            => MoveTo(direction, unit);

        public void MoveTo(Direction instructionDirection, int unit)
        {
            switch (instructionDirection)
            {
                case Direction.North:
                    x += unit;
                    break;
                case Direction.East:
                    y += unit;
                    break;
                case Direction.South:
                    x -= unit;
                    break;
                case Direction.West:
                    y -= unit;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void TurnRight(int degree)
            => direction = degree switch
            {
                90 when direction == Direction.East => Direction.South,
                180 when direction == Direction.East => Direction.West,
                270 when direction == Direction.East => Direction.North,

                90 when direction == Direction.South => Direction.West,
                180 when direction == Direction.South => Direction.North,
                270 when direction == Direction.South => Direction.East,

                90 when direction == Direction.West => Direction.North,
                180 when direction == Direction.West => Direction.East,
                270 when direction == Direction.West => Direction.South,

                90 when direction == Direction.North => Direction.East,
                180 when direction == Direction.North => Direction.South,
                270 when direction == Direction.North => Direction.West,

                _ => direction
            };

        public void TurnLeft(int degree)
            => TurnRight(360 - degree);
    }

    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    public static class NavigationInstructionsParser
    {
        public static IEnumerable<NavigationInstruction> Parse(string navigationInstructionsDescription)
        {
            return navigationInstructionsDescription
                .Split("\n")
                .Select(
                    navigationInstructionDescription =>
                        NavigationInstruction.CreateInstance(
                            ExtractAction(navigationInstructionDescription),
                            ExtractValue(navigationInstructionDescription)));
        }

        private static int ExtractValue(string navigationInstructionDescription)
            => int.Parse(navigationInstructionDescription[1..]);

        private static char ExtractAction(string navigationInstructionDescription)
            => navigationInstructionDescription[0];
    }

    public abstract record NavigationInstruction(char Action, int Value)
    {
        public static NavigationInstruction CreateInstance(char action, int value)
        {
            return action switch
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

        public abstract void Execute(Ship ship);
    }

    public record ForwardNavigationInstruction
        : NavigationInstruction
    {
        public ForwardNavigationInstruction(char action, int value)
            : base(action, value)
        {
        }

        public override void Execute(Ship ship)
            => ship.MoveForward(Value);
    }

    public record RightNavigationInstruction
        : NavigationInstruction
    {
        public RightNavigationInstruction(char action, int value)
            : base(action, value)
        {
        }

        public override void Execute(Ship ship)
            => ship.TurnRight(Value);
    }

    public record LeftNavigationInstruction
        : NavigationInstruction
    {
        public LeftNavigationInstruction(char action, int value)
            : base(action, value)
        {
        }

        public override void Execute(Ship ship)
            => ship.TurnLeft(Value);
    }

    public record WestNavigationInstruction
        : NavigationInstruction
    {
        public WestNavigationInstruction(char action, int value)
            : base(action, value)
        {
        }

        public override void Execute(Ship ship)
            => ship.MoveTo(Direction.West, Value);
    }

    public record EastNavigationInstruction
        : NavigationInstruction
    {
        public EastNavigationInstruction(char action, int value)
            : base(action, value)

        {
        }

        public override void Execute(Ship ship)
            => ship.MoveTo(Direction.East, Value);
    }

    public record NorthNavigationInstruction
        : NavigationInstruction
    {
        public NorthNavigationInstruction(char action, int value)
            : base(action, value)
        {
        }

        public override void Execute(Ship ship)
            => ship.MoveTo(Direction.North, Value);
    }

    public record SouthNavigationInstruction
        : NavigationInstruction
    {
        public SouthNavigationInstruction(char action, int value)
            : base(action, value)
        {
        }

        public override void Execute(Ship ship)
            => ship.MoveTo(Direction.South, Value);
    }
}