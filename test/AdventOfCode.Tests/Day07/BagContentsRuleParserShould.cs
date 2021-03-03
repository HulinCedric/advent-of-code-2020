using Xunit;

namespace AdventOfCode.Day07.Tests
{
    public class BagContentsRuleParserShould
    {
        [Theory]
        [InlineData("bright white bags contain 1 shiny gold bag.", "bright white", "shiny gold")]
        public void Parse_bag_content_rule_hold_one_bag_type(
            string bagContentsRuleDescription,
            string expectedBagColor,
            string expectedHoldBagColor)
        {
            // When
            var bagContentsRule = BagContentsRuleParser
                .Parse(bagContentsRuleDescription);

            //Then
            Assert.Equal(expectedBagColor, bagContentsRule.BagColor);
            Assert.Collection(bagContentsRule.HoldBagsColor,
                holdBagColor => Assert.Equal(expectedHoldBagColor, holdBagColor));
        }

        [Theory]
        [InlineData("light red bags contain 1 bright white bag, 2 muted yellow bags.", "light red", "bright white", "muted yellow")]
        [InlineData("dark orange bags contain 3 bright white bags, 4 muted yellow bags.", "dark orange", "bright white", "muted yellow")]
        public void Parse_bag_content_rule_hold_two_bag_types(
            string bagContentsRuleDescription,
            string expectedBagColor,
            string firstExpectedHoldBagColor,
            string secondExpectedHoldBagColor)
        {
            // When
            var bagContentsRule = BagContentsRuleParser
                .Parse(bagContentsRuleDescription);

            //Then
            Assert.Equal(bagContentsRule.BagColor, expectedBagColor);
            Assert.Collection(bagContentsRule.HoldBagsColor,
                holdBagColor => Assert.Equal(firstExpectedHoldBagColor, holdBagColor),
                holdBagColor => Assert.Equal(secondExpectedHoldBagColor, holdBagColor));
        }

        [Theory]
        [InlineData(
            "vibrant indigo bags contain 2 striped purple bags, 4 vibrant green bags, 3 dotted purple bags, 1 vibrant turquoise bag.",
            "vibrant indigo",
            "striped purple",
            "vibrant green",
            "dotted purple",
            "vibrant turquoise")]
        public void Parse_bag_content_rule_hold_four_bag_types(
            string bagContentsRuleDescription,
            string expectedBagColor,
            string firstExpectedHoldBagColor,
            string secondExpectedHoldBagColor,
            string thirdExpectedHoldBagColor,
            string fourthExpectedHoldBagColor)
        {
            // When
            var bagContentsRule = BagContentsRuleParser
                .Parse(bagContentsRuleDescription);

            //Then
            Assert.Equal(bagContentsRule.BagColor, expectedBagColor);
            Assert.Collection(bagContentsRule.HoldBagsColor,
                holdBagColor => Assert.Equal(firstExpectedHoldBagColor, holdBagColor),
                holdBagColor => Assert.Equal(secondExpectedHoldBagColor, holdBagColor),
                holdBagColor => Assert.Equal(thirdExpectedHoldBagColor, holdBagColor),
                holdBagColor => Assert.Equal(fourthExpectedHoldBagColor, holdBagColor));
        }

        [Theory]
        [InlineData("faded blue bags contain no other bags.", "faded blue")]
        [InlineData("dotted black bags contain no other bags.", "dotted black")]
        public void Parse_bag_content_rule_hold_zero_bag_type(
            string bagContentsRuleDescription,
            string expectedBagColor)
        {
            // When
            var bagContentsRule = BagContentsRuleParser
                .Parse(bagContentsRuleDescription);

            //Then
            Assert.Equal(expectedBagColor, bagContentsRule.BagColor);
            Assert.Empty(bagContentsRule.HoldBagsColor);
        }
    }
}