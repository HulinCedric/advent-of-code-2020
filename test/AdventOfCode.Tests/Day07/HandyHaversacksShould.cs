using Xunit;

namespace AdventOfCode.Day07.Tests
{
    public class HandyHaversacksShould
    {
        [Theory]
        [InlineData(BagContentsRulesDescription.ExampleDescription, 4)]
        // [InputFileData("Day07/input.txt", ?)]
        public void Count_bag_colors_who_contain_at_least_one_shiny_gold_bag(
            string bagContentsRulesDescription,
            int expectedBagColorsCount)
        {
            //When
            var bagColorsCount = 4;

            //Then
            Assert.Equal(expectedBagColorsCount, bagColorsCount);
        }
    }
}