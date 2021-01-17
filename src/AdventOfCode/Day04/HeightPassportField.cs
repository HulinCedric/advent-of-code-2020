namespace AdventOfCode.Day04
{
    public class HeightPassportField
        : PassportField
    {
        public HeightPassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
            => false;
    }
}