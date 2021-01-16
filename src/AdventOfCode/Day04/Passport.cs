using System.Collections.Generic;

namespace AdventOfCode.Day04
{
    public class Passport : AbstractPassport
    {
        internal Passport(string passportDescription)
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
            "pid",
            "cid"
        };
    }
}