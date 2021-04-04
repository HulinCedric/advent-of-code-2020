using Xunit;

namespace AdventOfCode.Day12
{
    public class RainRisk
    {
        [Theory]
        [InlineData(NavigationInstructionsDescription.Example, 25)]
        // [InputFileData("Day12/input.txt", ?)]
        public void Determine_Manhattan_distance_between_location_and_the_Ships_starting_position(
            string navigationInstructionsDescription,
            int expectedManhattanDistance)
        {
            // Given

            // When

            // Then
            Assert.Equal(expectedManhattanDistance, expectedManhattanDistance);
        }
    }
}