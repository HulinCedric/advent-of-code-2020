using System.Linq;

namespace AdventOfCode.Day07
{
    public static class BagContentsRulesParser
    {
        public static BagContentsRules Parse(string bagContentsRulesDescription)
        {
            return new BagContentsRules(bagContentsRulesDescription.Split("\n").ToList());
        }
    }
}