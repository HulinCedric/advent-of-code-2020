using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day04.PassportFields
{
    public class EyeColorPassportField
        : PassportField
    {
        private static readonly IEnumerable<string> eyeColors = new List<string>
        {
            "amb",
            "blu",
            "brn",
            "gry",
            "grn",
            "hzl",
            "oth",
        };

        internal EyeColorPassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
            => eyeColors.Any(eyeColor => eyeColor == value);
    }
}