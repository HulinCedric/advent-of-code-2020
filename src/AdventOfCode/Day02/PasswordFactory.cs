namespace AdventOfCode.Day02
{
    public class PasswordFactory
    {
        public static Password CreatePasswordWithOccurrencePolicy(string passwordAndPoliciyDescriptions)
            => new(
                GetPassword(passwordAndPoliciyDescriptions),
                new PasswordOccurrencePolicy(
                    GetFirstParameterPolicy(passwordAndPoliciyDescriptions),
                    GetSecondParameterPolicy(passwordAndPoliciyDescriptions),
                    GetCharacter(passwordAndPoliciyDescriptions)));

        public static Password CreatePasswordWithPositionPolicy(string passwordAndPoliciyDescriptions)
            => new(
                GetPassword(passwordAndPoliciyDescriptions),
                new PasswordPositionPolicy(
                    GetFirstParameterPolicy(passwordAndPoliciyDescriptions),
                    GetSecondParameterPolicy(passwordAndPoliciyDescriptions),
                    GetCharacter(passwordAndPoliciyDescriptions)));

        private static int GetFirstParameterPolicy(string passwordAndPoliciyDescriptions)
            => int.Parse(passwordAndPoliciyDescriptions[..IndexOfPolicySeparator(passwordAndPoliciyDescriptions)]);

        private static int GetSecondParameterPolicy(string passwordAndPoliciyDescriptions)
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