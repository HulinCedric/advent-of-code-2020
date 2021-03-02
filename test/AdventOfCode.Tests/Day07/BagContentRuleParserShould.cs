using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day07.Tests
{
    public class BagContentRuleParserShould
    {
        [Theory]
        [InlineData("bright white bags contain 1 shiny gold bag.", "bright white", "shiny gold")]
        public void Parse_bag_content_rule_hold_one_bag_type(
            string bagContentsRuleDescription,
            string expectedBagColor,
            string expectedHoldBagColor)
        {
            // When
            var bagContentsRule = BagContentRuleParser
                .Parse(bagContentsRuleDescription);

            //Then
            Assert.Equal(expectedBagColor, bagContentsRule.BagColor);
            Assert.Collection(bagContentsRule.HoldBagsColor,
                holdBagColor => Assert.Equal(expectedHoldBagColor, holdBagColor));
        }

        [Theory]
        [InlineData("dark orange bags contain 3 bright white bags, 4 muted yellow bags.", "dark orange", "bright white", "muted yellow")]
        [InlineData("shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.", "shiny gold", "dark olive", "vibrant plum")]
        public void Parse_bag_content_rule_hold_two_bag_types(
            string bagContentsRuleDescription,
            string expectedBagColor,
            string firstExpectedHoldBagColor,
            string secondExpectedHoldBagColor)
        {
            // When
            var bagContentsRule = BagContentRuleParser
                .Parse(bagContentsRuleDescription);

            //Then
            Assert.Equal(bagContentsRule.BagColor, expectedBagColor);
            Assert.Collection(bagContentsRule.HoldBagsColor,
                holdBagColor => Assert.Equal(firstExpectedHoldBagColor, holdBagColor),
                holdBagColor => Assert.Equal(secondExpectedHoldBagColor, holdBagColor));
        }

        [Theory]
        [InlineData("faded blue bags contain no other bags.", "faded blue")]
        public void Parse_bag_content_rule_hold_zero_bag_type(
            string bagContentsRuleDescription,
            string expectedBagColor)
        {
            // When
            var bagContentsRule = BagContentRuleParser
                .Parse(bagContentsRuleDescription);

            //Then
            Assert.Equal(expectedBagColor, bagContentsRule.BagColor);
            Assert.Empty(bagContentsRule.HoldBagsColor);
        }
    }

    internal static class BagContentRuleParser
    {
        internal static BagContentRule Parse(string bagContentRuleDescription)
        {
            var bagColor = ExtractBagColor(bagContentRuleDescription);
            var holdBagColors = ExtractHoldBagColors(bagContentRuleDescription);

            return new BagContentRule(bagColor, holdBagColors);
        }

        private static string ExtractBagColor(string bagContentRuleDescription)
        {
            var bagIndex = bagContentRuleDescription.IndexOf(" bags");
            return bagContentRuleDescription[0..bagIndex];
        }

        private static IEnumerable<string> ExtractHoldBagColors(string bagContentRuleDescription)
        {
            if (bagContentRuleDescription.Contains("no other bags"))
            {
                return Enumerable.Empty<string>();
            }

            var contentDelimiterIndex = bagContentRuleDescription.IndexOf("contain ") + "contain ".Length;
            var contentDescription = bagContentRuleDescription.Substring(contentDelimiterIndex);

            return contentDescription
                .Split(",", options: StringSplitOptions.TrimEntries)
                .Select(holdBagDescription => ExtractHoldBagColor(holdBagDescription));
        }

        private static string ExtractHoldBagColor(string contentDescription)
        {
            var holdBagIndex = contentDescription.IndexOf(" bag");
            var skipNumberOfBag = contentDescription.IndexOf(" ") + " ".Length;
            return contentDescription[skipNumberOfBag..holdBagIndex];
        }
    }

    internal record BagContentRule(string BagColor, IEnumerable<string> HoldBagsColor);
}