using System.Linq;

namespace AdventOfCode.Day04
{
    public class IssueYearPassportField
        : PassportField
    {
        private const int AtLeast = 2010;
        private const int AtMost = 2020;

        internal IssueYearPassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
            =>
            value.All(c => char.IsDigit(c)) &&
            int.Parse(value) >= AtLeast &&
            int.Parse(value) <= AtMost;
    }
}