namespace AdventOfCode.Day04.PassportFields
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