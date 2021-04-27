namespace AdventOfCode.Day02
{
    public interface IPasswordPolicy
    {
        bool Validate(string password);
    }
}