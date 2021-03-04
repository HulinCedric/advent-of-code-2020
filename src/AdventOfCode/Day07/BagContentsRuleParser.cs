using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day07
{
    public static class BagContentsRuleParser
    {
        public static BagContentsRule Parse(string bagContentRuleDescription)
        {
            var bagColor = ExtractBagColor(bagContentRuleDescription);
            var holdBagCounts = ExtractHoldBagCounts(bagContentRuleDescription);

            return new BagContentsRule(new Bag(bagColor), holdBagCounts);
        }

        private static string ExtractBagColor(string bagContentRuleDescription)
        {
            var bagIndex = bagContentRuleDescription.IndexOf(" bags");
            return bagContentRuleDescription[0..bagIndex];
        }

        private static IEnumerable<BagCount> ExtractHoldBagCounts(string bagContentRuleDescription)
        {
            if (bagContentRuleDescription.Contains("no other bags"))
            {
                return Enumerable.Empty<BagCount>();
            }

            var contentDelimiterIndex = bagContentRuleDescription.IndexOf("contain ") + "contain ".Length;
            var contentDescription = bagContentRuleDescription.Substring(contentDelimiterIndex);

            return contentDescription
                .Split(",", options: StringSplitOptions.TrimEntries)
                .Select(holdBagDescription => ExtractHoldBagCount(holdBagDescription));
        }

        private static BagCount ExtractHoldBagCount(string contentDescription)
        {
            var holdBagNumber = ExtractHoldBagNumber(contentDescription);
            var holdBagColor = ExtractHoldBagColor(contentDescription);
            return new BagCount(holdBagNumber, new Bag(holdBagColor));
        }

        private static int ExtractHoldBagNumber(string contentDescription)
        {
            var holdBagIndex = contentDescription.IndexOf(" ");
            return int.Parse(contentDescription[..holdBagIndex]);
        }

        private static string ExtractHoldBagColor(string contentDescription)
        {
            var holdBagIndex = contentDescription.IndexOf(" bag");
            var skipNumberOfBag = contentDescription.IndexOf(" ") + " ".Length;
            return contentDescription[skipNumberOfBag..holdBagIndex];
        }
    }
}