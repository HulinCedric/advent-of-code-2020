namespace AdventOfCode.Day2.Tests
{
    public class Password
    {
        private readonly string password;
        private readonly PasswordPolicy policy;

        public Password(
            string password,
            PasswordPolicy policy)
        {
            this.password = password;
            this.policy = policy;
        }

        public bool IsValid()
            => policy.Validate(password);
    }
}