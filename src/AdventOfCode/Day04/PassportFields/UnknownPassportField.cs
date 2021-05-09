namespace AdventOfCode.Day04.PassportFields
{
    public class UnknownPassportField
        : PassportField
    {
        private readonly string name;

        internal UnknownPassportField(string name, string value)
            : base(value)
            => this.name = name;

        public override bool IsValid()
            => false;
    }
}