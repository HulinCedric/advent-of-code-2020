namespace AdventOfCode.Day04
{
    public class CountryIdPassportField
        : PassportField
    {
        internal CountryIdPassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
            => true;
    }
}