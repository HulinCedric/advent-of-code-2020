using System.Linq;

namespace AdventOfCode.Day04
{
    public class BirthYearPassportField
        : PassportField
    {
        private const int AtLeast = 1920;
        private const int AtMost = 2002;

        internal BirthYearPassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
            =>
            value.All(c => char.IsDigit(c)) &&
            int.Parse(value) >= AtLeast &&
            int.Parse(value) <= AtMost;
    }
}