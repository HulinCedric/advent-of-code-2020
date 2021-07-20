using System.Linq;
using Xunit;

namespace AdventOfCode.Day14
{
    public class DockingData
    {
        [Theory]
        [InlineData(InitializationProgramDescription.Example, 165)]
        [InputFileData("Day14/input.txt", 15514035145260)]
        public void Determine_the_sum_of_all_values_left_in_memory_after_it_completes(
            string initializationProgramDescription,
            long expectedSum)
        {
            // Given
            var programInstructions = initializationProgramDescription.Split("\n");
            var memory = new Memory();
            var expectedSumMemoryValue = new MemoryValue(expectedSum);

            // When
            memory = programInstructions.Aggregate(
                memory,
                InitializationProgramInterpreter.Read);

            var actualSumMemoryValue = memory.Sum;

            // Then
            Assert.Equal(expectedSumMemoryValue, actualSumMemoryValue);
        }
    }
}