namespace AdventOfCode.Day04
{
    public class PassportFieldFactory
    {
        public static PassportField Create(string passportFieldDescription)
            => (PassportParser.ParsePassportFieldDescription(passportFieldDescription)) switch
            {
                ("byr", _) passportFieldInformations => new BirthYearPassportField(passportFieldInformations.Value),
                ("iyr", _) passportFieldInformations => new IssueYearPassportField(passportFieldInformations.Value),
                _ => new PassportField(PassportParser.ParsePassportFieldDescription(passportFieldDescription).Value),
            };
    }
}