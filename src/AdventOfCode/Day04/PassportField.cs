namespace AdventOfCode.Day04
{
    public class PassportField
    {
        protected readonly string value;

        public PassportField(string value)
            => this.value = value;

        public virtual bool IsValid()
            => false;
    }
}