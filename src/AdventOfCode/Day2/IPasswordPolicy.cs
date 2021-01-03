namespace AdventOfCode.Day2.Tests
{
    public interface IPasswordPolicy
    {
        bool Validate(string password);
    }
}