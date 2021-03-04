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
                .Select(ruleDescription => BagContentsRuleParser.Parse(ruleDescription))
                .ToList();
        }

        public IEnumerator<BagContentsRule> GetEnumerator()
        {
            return bagContentRules.GetEnumerator();
        }

        public IEnumerable<Bag> GetBagsContaining(Bag targetBag)
        {
            foreach (var directBagHolder in bagContentRules
                                            .Where(rule => rule.HoldBags
                                                .Any(holdBag => holdBag.Equals(targetBag)))
                                            .Select(rule => rule.Bag))
            {
                yield return directBagHolder;

                foreach (var indirectBagHolder in GetBagsContaining(directBagHolder))
                {
                    yield return indirectBagHolder;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}