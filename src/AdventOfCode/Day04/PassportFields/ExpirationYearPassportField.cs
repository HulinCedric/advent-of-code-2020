using System.Linq;

namespace AdventOfCode.Day04
{
    public class ExpirationYearPassportField
        : PassportField
    {
        private const int AtLeast = 2020;
        private const int AtMost = 2030;

        internal ExpirationYearPassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
            =>
            value.All(c => char.IsDigit(c)) &&
            int.Parse(value) >= AtLeast &&
            int.Parse(value) <= AtMost;
    }
}