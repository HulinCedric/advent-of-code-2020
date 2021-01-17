namespace AdventOfCode.Day04
{
    public class UnknownPassportField
        : PassportField
    {
        public UnknownPassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
            => false;
    }
}