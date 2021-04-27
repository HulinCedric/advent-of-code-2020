using System.Text.RegularExpressions;

namespace AdventOfCode.Day04.PassportFields
{
    public class HairColorPassportField
        : PassportField
    {
        private const string Characters_0_9 = "[0-9]";
        private const string Characters_a_f = "[a-f]";
        private const int Exactly6 = 6;
        private const string StartWithSharp = "#";

        internal HairColorPassportField(string value)
            : base(value)
        { }

        private string ValidRegexPattern
            => $"{StartWithSharp}({Characters_0_9}|{Characters_a_f}){{{Exactly6}}}";

        public override bool IsValid()
            => Regex.IsMatch(value, ValidRegexPattern);
    }
}