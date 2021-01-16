namespace AdventOfCode.Day04
{
    public class PassportFieldFactory
    {
        public static BirthYearPassportField Create(string passportFieldDescription)
        => new BirthYearPassportField(PassportParser.ParsePassportFieldDescription(passportFieldDescription).Value);
    }
}