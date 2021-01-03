namespace AdventOfCode.Day2.Tests
{
    public class PasswordFactory
    {
        public static Password CreatePassword(string passwordAndPoliciyDescriptions)
            => new Password(
                GetPassword(passwordAndPoliciyDescriptions),
                new PasswordPolicy(
                    GetAtLeast(passwordAndPoliciyDescriptions),
                    GetAtMost(passwordAndPoliciyDescriptions),
                    GetCharacter(passwordAndPoliciyDescriptions)));

        private static int GetAtLeast(string passwordAndPoliciyDescriptions)
            => int.Parse(passwordAndPoliciyDescriptions[..IndexOfPolicySeparator(passwordAndPoliciyDescriptions)]);

        private static int GetAtMost(string passwordAndPoliciyDescriptions)
            => int.Parse(passwordAndPoliciyDescriptions[(IndexOfPolicySeparator(passwordAndPoliciyDescriptions) + 1)..IndexOfCharacterSeparator(passwordAndPoliciyDescriptions)]);

        private static char GetCharacter(string passwordAndPoliciyDescriptions)
            => char.Parse(passwordAndPoliciyDescriptions[(IndexOfCharacterSeparator(passwordAndPoliciyDescriptions) + 1)..IndexOfPasswordSeparator(passwordAndPoliciyDescriptions)]);

        private static string GetPassword(string passwordAndPoliciyDescriptions)
            => passwordAndPoliciyDescriptions[(IndexOfPasswordSeparator(passwordAndPoliciyDescriptions) + 1)..];

        private static int IndexOfCharacterSeparator(string passwordAndPoliciyDescriptions)
            => passwordAndPoliciyDescriptions.IndexOf(' ');

        private static int IndexOfPasswordSeparator(string passwordAndPoliciyDescriptions)
            => passwordAndPoliciyDescriptions.IndexOf(':');

        private static int IndexOfPolicySeparator(string passwordAndPoliciyDescriptions)
            => passwordAndPoliciyDescriptions.IndexOf('-');
    }
}