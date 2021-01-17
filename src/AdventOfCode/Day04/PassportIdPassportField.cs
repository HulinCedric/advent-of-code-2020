using System.Linq;

namespace AdventOfCode.Day04
{
    public class PassportIdPassportField
        : PassportField
    {
        public PassportIdPassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
            => value.Length == 9 &&
            value.All(c => char.IsDigit(c));
    }
}