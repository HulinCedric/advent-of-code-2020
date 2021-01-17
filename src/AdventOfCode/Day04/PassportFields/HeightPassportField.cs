namespace AdventOfCode.Day04
{
    public class HeightPassportField
        : PassportField
    {
        internal HeightPassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
            => false;
    }
}