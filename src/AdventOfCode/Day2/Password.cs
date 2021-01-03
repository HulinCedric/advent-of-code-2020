namespace AdventOfCode.Day2.Tests
{
    public class Password
    {
        private readonly string password;
        private readonly IPasswordPolicy policy;

        public Password(
            string password,
            IPasswordPolicy policy)
        {
            this.password = password.Trim();
            this.policy = policy;
        }

        public bool IsValid()
            => policy.Validate(password);
    }
}