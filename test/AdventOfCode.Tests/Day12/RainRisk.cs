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
            var ship = new ShipWithDirection(Direction.East, 0, 0);

            // When
            foreach (var navigationInstruction in navigationInstructions)
                ship.Navigate(navigationInstruction);

            var actualManhattanDistance = ship.GetManhattanDistance();

            // Then
            Assert.Equal(expectedManhattanDistance, actualManhattanDistance);
        }
    }

    public abstract class Ship
    {
        protected Ship(int x, int y)
            => Position = new Position(x, y);

        protected Position Position { get; set; }

        public void Navigate(NavigationInstruction navigationInstruction)
            => navigationInstruction.Execute(this);

        public int GetManhattanDistance()
            => Math.Abs(Position.X) + Math.Abs(Position.Y);

        public void MoveForward(int unit)
            => Move(unit);

        public void MoveWest(int value)
            => Move(Direction.West, value);

        public void MoveEst(int value)
            => Move(Direction.East, value);

        public void MoveNorth(int value)
            => Move(Direction.North, value);

        public void MoveSouth(int value)
            => Move(Direction.South, value);

        public void TurnRight(int degree)
            => Turn(degree);

        public void TurnLeft(int degree)
            => Turn(360 - degree);

        protected abstract void Move(int unit);
        protected abstract void Move(Direction instructionDirection, int unit);
        protected abstract void Turn(int degree);
    }

    public record Position(int X, int Y);

    public class ShipWithDirection
        : Ship
    {
        private Direction direction;

        public ShipWithDirection(Direction direction, int x, int y)
            : base(x, y)
            => this.direction = direction;

        protected override void Move(int unit)
            => Move(direction, unit);

        protected override void Move(Direction instructionDirection, int unit)
            => Position = GetNewPosition(Position, instructionDirection, unit);

        protected override void Turn(int degree)
            => direction = GetNewDirection(direction, degree);

        private static Position GetNewPosition(
            Position initialPosition,
            Direction instructionDirection,
            int unit)
            => instructionDirection switch
            {
                Direction.North => initialPosition with
                {
                    X = initialPosition.X + unit
                },
                Direction.East => initialPosition with
                {
                    Y = initialPosition.Y + unit
                },
                Direction.South => initialPosition with
                {
                    X = initialPosition.X - unit
                },
                Direction.West => initialPosition with
                {
                    Y = initialPosition.Y - unit
                },
                _ => throw new ArgumentOutOfRangeException()
            };

        private static Direction GetNewDirection(Direction initialDirection, int degree)
            => (degree, initialDirection) switch
            {
                (90, Direction.East) => Direction.South,
                (180, Direction.East) => Direction.West,
                (270, Direction.East) => Direction.North,

                (90, Direction.South) => Direction.West,
                (180, Direction.South) => Direction.North,
                (270, Direction.South) => Direction.East,

                (90, Direction.West) => Direction.North,
                (180, Direction.West) => Direction.East,
                (270, Direction.West) => Direction.South,

                (90, Direction.North) => Direction.East,
                (180, Direction.North) => Direction.South,
                (270, Direction.North) => Direction.West,

                _ => initialDirection
            };
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
            => ship.MoveWest(Value);
    }

    public record EastNavigationInstruction
        : NavigationInstruction
    {
        public EastNavigationInstruction(char action, int value)
            : base(action, value)

        {
        }

        public override void Execute(Ship ship)
            => ship.MoveEst(Value);
    }

    public record NorthNavigationInstruction
        : NavigationInstruction
    {
        public NorthNavigationInstruction(char action, int value)
            : base(action, value)
        {
        }

        public override void Execute(Ship ship)
            => ship.MoveNorth(Value);
    }

    public record SouthNavigationInstruction
        : NavigationInstruction
    {
        public SouthNavigationInstruction(char action, int value)
            : base(action, value)
        {
        }

        public override void Execute(Ship ship)
            => ship.MoveSouth(Value);
    }
}