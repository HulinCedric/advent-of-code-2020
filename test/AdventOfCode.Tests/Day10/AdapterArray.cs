using System.Linq;
using Xunit;

namespace AdventOfCode.Day10
{
    public class AdapterArray
    {
        [Theory]
        [InlineData(AdaptersDescription.Example, 22, 7, 5)]
        // [InputFileData("Day10/input.txt", ?, ?, ?)]
        public void Find_jolts_differences_in_chain_that_uses_all_of_the_adapters(
            string adaptersDescription,
            int expectedDeviceBuiltInJoltage,
            int expected1JoltDifferences,
            int expected3JoltDifferences)
        {
            // Given
            var adaptersOutputsJoltages = adaptersDescription
                .Split("\n")
                .Select(int.Parse)
                .ToList();

            // When
            var actualDeviceBuiltInJoltage = adaptersOutputsJoltages.Max() + 3;

            // Then
            Assert.Equal(expectedDeviceBuiltInJoltage, actualDeviceBuiltInJoltage);
        }
    }
}