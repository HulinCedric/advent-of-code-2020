using System;
using System.IO;

namespace AdventOfCode.Day04.Tests
{
    public static class BatchFileDescription
    {
        public static readonly string PartOneExampleDescription =
        PassportDescription.First +
        Environment.NewLine +
        Environment.NewLine +
        PassportDescription.Second +
        Environment.NewLine +
        Environment.NewLine +
        PassportDescription.Third +
        Environment.NewLine +
        Environment.NewLine +
        PassportDescription.Fourth;

        public static readonly string PartTwoValidExampleDescription =
            "pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980" + Environment.NewLine +
            "hcl:#623a2f" + Environment.NewLine +
            Environment.NewLine +
            "eyr:2029 ecl:blu cid:129 byr:1989" + Environment.NewLine +
            "iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm" + Environment.NewLine +
            Environment.NewLine +
            "hcl:#888785" + Environment.NewLine +
            "hgt:164cm byr:2001 iyr:2015 cid:88" + Environment.NewLine +
            "pid:545766238 ecl:hzl" + Environment.NewLine +
            "eyr:2022" + Environment.NewLine +
            Environment.NewLine +
            "iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719";

        public static readonly string PartTwoInvalidExampleDescription =
            "eyr:1972 cid:100" + Environment.NewLine +
            "hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926" + Environment.NewLine +
            Environment.NewLine +
            "iyr:2019" + Environment.NewLine +
            "hcl:#602927 eyr:1967 hgt:170cm" + Environment.NewLine +
            "ecl:grn pid:012533040 byr:1946" + Environment.NewLine +
            Environment.NewLine +
            "hcl:dab227 iyr:2012" + Environment.NewLine +
            "ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277" + Environment.NewLine +
            Environment.NewLine +
            "hgt:59cm ecl:zzz" + Environment.NewLine +
            "eyr:2038 hcl:74454a iyr:2023" + Environment.NewLine +
            "pid:3556412378 byr:2007" + Environment.NewLine;

        public static string ProblemDescription
            => string.Join(
                Environment.NewLine,
                File.ReadAllLines(
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory, "Day04/input.txt")));
    }
}