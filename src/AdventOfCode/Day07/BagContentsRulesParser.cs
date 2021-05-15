using System.Linq;

namespace AdventOfCode.Day07
{
    public static class BagContentsRulesParser
    {
        public static BagContentsRules Parse(string bagContentsRulesDescription)
            => new BagContentsRules(bagContentsRulesDescription.Split("\n").ToList());
    }
}