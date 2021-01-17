namespace AdventOfCode.Day04
{
    public class PassportFieldFactory
    {
        public static PassportField Create(string passportFieldDescription)
            => (PassportParser.ParsePassportFieldDescription(passportFieldDescription)) switch
            {
                ("byr", _) passportFieldInformations => new BirthYearPassportField(passportFieldInformations.Value),
                ("iyr", _) passportFieldInformations => new IssueYearPassportField(passportFieldInformations.Value),
                ("eyr", _) passportFieldInformations => new ExpirationYearPassportField(passportFieldInformations.Value),
                ("hgt", _) passportFieldInformations when passportFieldInformations.Value.EndsWith("cm") => new HeightInCentimetrePassportField(passportFieldInformations.Value),
                ("hgt", _) passportFieldInformations when passportFieldInformations.Value.EndsWith("in") => new HeightInInchPassportField(passportFieldInformations.Value),
                ("hgt", _) passportFieldInformations => new HeightPassportField(passportFieldInformations.Value),
                ("hcl", _) passportFieldInformations => new HairColorPassportField(passportFieldInformations.Value),
                ("ecl", _) passportFieldInformations => new EyeColorPassportField(passportFieldInformations.Value),
                ("pid", _) passportFieldInformations => new PassportIdPassportField(passportFieldInformations.Value),
                ("cid", _) passportFieldInformations => new CountryIdPassportField(passportFieldInformations.Value),
                _ => new UnknownPassportField(PassportParser.ParsePassportFieldDescription(passportFieldDescription).Value),
            };
    }
}