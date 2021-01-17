namespace AdventOfCode.Day04
{
    public class CountryIdPassportField
        : PassportField
    {
        public CountryIdPassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
            => true;
    }
}