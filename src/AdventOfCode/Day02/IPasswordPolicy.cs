namespace AdventOfCode.Day02.Tests
{
    public interface IPasswordPolicy
    {
        bool Validate(string password);
    }
}