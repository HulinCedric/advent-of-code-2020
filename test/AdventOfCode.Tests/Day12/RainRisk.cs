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
        public void
            Determine_Manhattan_distance_between_ships_with_directions_starting_position_and_instructions_location(
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

        [Theory]
        [InlineData(NavigationInstructionsDescription.Example, 286)]
        // [InputFileData("Day12/input.txt", 1133)]
        public void
            Determine_Manhattan_distance_between_ships_with_waypoint_starting_position_and_instructions_location(
                string navigationInstructionsDescription,
                int expectedManhattanDistance)
        {
            // Given
            var navigationInstructions = NavigationInstructionsParser.Parse(navigationInstructionsDescription);
            var ship = new ShipWithWaypoint(new Waypoint(10, 1), 0, 0);

            // When
            foreach (var navigationInstruction in navigationInstructions)
                ship.Navigate(navigationInstruction);

            var actualManhattanDistance = ship.GetManhattanDistance();

            // Then
            Assert.Equal(expectedManhattanDistance, actualManhattanDistance);
        }
    }

    public class Waypoint
    {
        private readonly Position position;

        public Waypoint(int x, int y)
            => position = new Position(x, y);
    }

    public class ShipWithWaypoint
        : Ship
    {
        private readonly Waypoint waypoint;

        public ShipWithWaypoint(Waypoint waypoint, int x, int y)
            : base(214, -72)
            => this.waypoint = waypoint;

        protected override void Move(int unit)
        {
            // throw new NotImplementedException();
        }

        protected override void Move(Direction instructionDirection, int unit)
        {
            // throw new NotImplementedException();
        }

        protected override void Turn(int degree)
        {
            // throw new NotImplementedException();
        }
    }
}