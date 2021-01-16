using System.Collections.Generic;

namespace AdventOfCode.Day04
{
    public class Credential : AbstractPassport
    {
        internal Credential(string passportDescription)
        : base(passportDescription)
        {
        }

        protected override IEnumerable<string> GetRequiredFieldsDescritpions()
        => new HashSet<string> {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid"
        };
    }
}