using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day07
{
    public class BagContentsRules
        : IEnumerable<BagContentsRule>
    {
        private List<BagContentsRule> bagContentRules;

        public BagContentsRules(List<string> bagContentsRulesDescription)
        {
            bagContentRules = bagContentsRulesDescription
                .Select(BagContentsRuleParser.Parse)
                .ToList();
        }

        public IEnumerator<BagContentsRule> GetEnumerator()
        {
            return bagContentRules.GetEnumerator();
        }

        public IEnumerable<Bag> GetBagsContaining(Bag targetBag)
        {
            foreach (var directBagHolder in bagContentRules
                                            .Where(rule => rule.HoldBagCounts
                                                .Any(holdBagCount => holdBagCount.Bag.Equals(targetBag)))
                                            .Select(rule => rule.Bag))
            {
                yield return directBagHolder;

                foreach (var indirectBagHolder in GetBagsContaining(directBagHolder))
                {
                    yield return indirectBagHolder;
                }
            }
        }

        public int SumRequiredBagsFor(Bag targetBag)
        {
            var requiredBadSum = 0;
            foreach (var requiredBagsCount in bagContentRules
                                            .Where(rule => rule.Bag == targetBag)
                                            .SelectMany(rule => rule.HoldBagCounts))
            {
                requiredBadSum += requiredBagsCount.BagNumber;
                requiredBadSum += requiredBagsCount.BagNumber * SumRequiredBagsFor(requiredBagsCount.Bag);
            }

            return requiredBadSum;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}