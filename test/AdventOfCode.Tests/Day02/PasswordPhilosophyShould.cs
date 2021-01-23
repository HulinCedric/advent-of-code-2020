using System.Linq;
using Xunit;

namespace AdventOfCode.Day02.Tests
{
    public class PasswordPhilosophyShould
    {
        private const string passwsordsAndPoliciesDescriptionsExample = "1-3 a: abcde\n1-3 b: cdefg\n2-9 c: ccccccccc";

        [Theory]
        [InlineData(passwsordsAndPoliciesDescriptionsExample, 2)]
        [InputFileData("Day02/input.txt", 474)]
        public void Count_x_valid_Passwords_with_OccurencePolicy(
            string passwsordsAndPoliciesDescriptions,
            int expectedValidPasswordsCount)
        {
            //Given
            var passwordsWithOccurrencePolicy = PasswsordAndPolicyParser.ParsePasswsordsAndPoliciesDescriptions(passwsordsAndPoliciesDescriptions)
                .Select(passwsordsAndPoliciesDescription => PasswordFactory.CreatePasswordWithOccurrencePolicy(passwsordsAndPoliciesDescription));

            //When
            var validPasswordsCount = passwordsWithOccurrencePolicy
                .Where(password => password.IsValid())
                .Count();

            //Then
            Assert.Equal(expectedValidPasswordsCount, validPasswordsCount);
        }

        [Theory]
        [InlineData(passwsordsAndPoliciesDescriptionsExample, 1)]
        [InputFileData("Day02/input.txt", 745)]
        public void Count_x_valid_Passwords_with_PositionPolicy(
            string passwsordsAndPoliciesDescriptions,
            int expectedValidPasswordsCount)
        {
            //Given
            var passwordsWithPositionPolicy = PasswsordAndPolicyParser.ParsePasswsordsAndPoliciesDescriptions(passwsordsAndPoliciesDescriptions)
                .Select(passwsordsAndPoliciesDescription => PasswordFactory.CreatePasswordWithPositionPolicy(passwsordsAndPoliciesDescription));

            //When
            var validPasswordsCount = passwordsWithPositionPolicy
                .Where(password => password.IsValid())
                .Count();

            //Then
            Assert.Equal(expectedValidPasswordsCount, validPasswordsCount);
        }
    }
}