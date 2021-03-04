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
            var holdBagColors = ExtractHoldBagColors(bagContentRuleDescription);

            return new BagContentsRule(new Bag(bagColor), holdBagColors);
        }

        private static string ExtractBagColor(string bagContentRuleDescription)
        {
            var bagIndex = bagContentRuleDescription.IndexOf(" bags");
            return bagContentRuleDescription[0..bagIndex];
        }

        private static IEnumerable<Bag> ExtractHoldBagColors(string bagContentRuleDescription)
        {
            if (bagContentRuleDescription.Contains("no other bags"))
            {
                return Enumerable.Empty<Bag>();
            }

            var contentDelimiterIndex = bagContentRuleDescription.IndexOf("contain ") + "contain ".Length;
            var contentDescription = bagContentRuleDescription.Substring(contentDelimiterIndex);

            return contentDescription
                .Split(",", options: StringSplitOptions.TrimEntries)
                .Select(holdBagDescription => new Bag(ExtractHoldBagColor(holdBagDescription)));
        }

        private static string ExtractHoldBagColor(string contentDescription)
        {
            var holdBagIndex = contentDescription.IndexOf(" bag");
            var skipNumberOfBag = contentDescription.IndexOf(" ") + " ".Length;
            return contentDescription[skipNumberOfBag..holdBagIndex];
        }
    }
}