using System.Linq;
using Xunit;

namespace AdventOfCode.Day10
{
    public class AdapterArray
    {
        [Theory]
        [InlineData(AdaptersDescription.Example, 22, 7, 5)]
        [InlineData(AdaptersDescription.LageExample, 52, 22, 10)]
        [InputFileData("Day10/input.txt", 177, 69, 36)]
        public void Find_jolts_differences_in_chain_that_uses_all_of_the_adapters(
            string adaptersDescription,
            int expectedDeviceBuiltInJoltage,
            int expected1JoltDifferences,
            int expected3JoltDifferences)
        {
            // Given
            var adaptersJoltages = adaptersDescription
                .Split("\n")
                .Select(int.Parse)
                .ToList();

            const int chargingOutletJoltage = 0;
            adaptersJoltages.Add(chargingOutletJoltage);

            var actualDeviceBuiltInJoltage = adaptersJoltages.Max() + 3;
            adaptersJoltages.Add(actualDeviceBuiltInJoltage);

            adaptersJoltages.Sort();

            // When
            var chainedAdapters = adaptersJoltages.Zip(
                adaptersJoltages.Skip(1),
                (fromAdapter, toAdapter) => (fromAdapter, toAdapter));

            var actual1JoltDifferences = 0;
            var actual3JoltDifferences = 0;
            foreach (var pluggedAdapters in chainedAdapters)
            {
                switch (pluggedAdapters.toAdapter - pluggedAdapters.fromAdapter)
                {
                    case 1:
                        actual1JoltDifferences++;
                        break;
                    case 3:
                        actual3JoltDifferences++;
                        break;
                }
            }

            // Then
            Assert.Equal(expectedDeviceBuiltInJoltage, actualDeviceBuiltInJoltage);
            Assert.Equal(expected1JoltDifferences, actual1JoltDifferences);
            Assert.Equal(expected3JoltDifferences, actual3JoltDifferences);
        }
    }
}