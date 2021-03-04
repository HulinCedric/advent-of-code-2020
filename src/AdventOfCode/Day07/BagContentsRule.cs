using System.Collections.Generic;

namespace AdventOfCode.Day07
{
    public record BagContentsRule(Bag Bag, IEnumerable<Bag> HoldBags);
}