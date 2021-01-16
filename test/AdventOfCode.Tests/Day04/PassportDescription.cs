using System;

namespace AdventOfCode.Day04.Tests
{
    public static class PassportDescription
    {
        public static readonly string First =
        "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd" + Environment.NewLine +
        "byr:1937 iyr:2017 cid:147 hgt:183cm";

        public static readonly string Second =
        "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884" + Environment.NewLine +
        "hcl:#cfa07d byr:1929";

        public static readonly string Third =
        "hcl:#ae17e1 iyr:2013" + Environment.NewLine +
        "eyr:2024" + Environment.NewLine +
        "ecl:brn pid:760753108 byr:1931" + Environment.NewLine +
        "hgt:179cm";

        public static readonly string Fourth =
        "hcl:#cfa07d eyr:2025 pid:166559648" + Environment.NewLine +
        "iyr:2011 ecl:brn hgt:59in";
    }
}