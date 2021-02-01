using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    internal record Bag(string Color);

    internal class BagContentRules
        : IEnumerable<string>
    {
        private List<string> bagContentRules;

        public BagContentRules(List<string> bagContentsRulesDescription)
        {

            bagContentRules = bagContentsRulesDescription;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return bagContentRules.GetEnumerator();
        }

        internal IEnumerable<Bag> GetBagsContaining(Bag shinyGoldBag)
        {
            return Enumerable.Range(0, 4).Select(i => new Bag($"{i}"));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}