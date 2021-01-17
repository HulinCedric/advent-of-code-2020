using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Day04
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

        public EyeColorPassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
            => eyeColors.Any(eyeColor => eyeColor == value);
    }
}