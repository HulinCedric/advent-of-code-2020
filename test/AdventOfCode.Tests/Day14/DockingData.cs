using Xunit;

namespace AdventOfCode.Day14
{
    public class DockingData
    {
        [Theory]
        [InlineData(InitializationProgramDescription.Example, 165)]
        // [InputFileData("Day14/input.txt", ?)]
        public void Determine_the_sum_of_all_values_left_in_memory_after_it_completes(
            string initializationProgramDescription,
            int expectedSum)
        {
            // Given

            // When

            // Then
            Assert.Equal(expectedSum, expectedSum);
        }
    }
}