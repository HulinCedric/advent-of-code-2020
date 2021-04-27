namespace AdventOfCode.Day04.PassportFields
{
    public abstract class PassportField
    {
        protected readonly string value;

        protected PassportField(string value)
            => this.value = value;

        public abstract bool IsValid();
    }
}