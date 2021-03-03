using System.Linq;
using Xunit;

namespace AdventOfCode.Day07.Tests
{
    public class HandyHaversacksShould
    {
        [Theory]
        [InlineData(BagContentsRulesDescription.ExampleDescription, 4)]
        [InputFileData("Day07/input.txt", 144)]
        public void Count_bag_colors_who_contain_at_least_one_shiny_gold_bag(
            string bagContentsRulesDescription,
            int expectedBagColorsCount)
        {
            //Given
            var bagContentsRules = BagContentsRulesParser.Parse(bagContentsRulesDescription);
            var shinyGoldBag = new Bag(Color: "shiny gold");

            //When
            var bagColorsCount = bagContentsRules
                .GetBagsContaining(shinyGoldBag)
                .Select(bag => bag.Color)
                .Distinct()
                .Count();

            //Then
            Assert.Equal(expectedBagColorsCount, bagColorsCount);
        }
    }
}