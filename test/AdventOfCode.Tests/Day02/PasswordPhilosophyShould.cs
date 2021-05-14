using System.Linq;
using Xunit;

namespace AdventOfCode.Day02
{
    public class PasswordPhilosophyShould
    {
        private const string PasswsordsAndPoliciesDescriptionsExample = "1-3 a: abcde\n1-3 b: cdefg\n2-9 c: ccccccccc";

        [Theory]
        [InlineData(PasswsordsAndPoliciesDescriptionsExample, 2)]
        [InputFileData("Day02/input.txt", 474)]
        public void Count_x_valid_Passwords_with_OccurencePolicy(
            string passwsordsAndPoliciesDescriptions,
            int expectedValidPasswordsCount)
        {
            //Given
            var passwordsWithOccurrencePolicy = PasswsordAndPolicyParser
                .ParsePasswsordsAndPoliciesDescriptions(passwsordsAndPoliciesDescriptions)
                .Select(PasswordFactory.CreatePasswordWithOccurrencePolicy);

            //When
            var validPasswordsCount = passwordsWithOccurrencePolicy
                .Count(password => password.IsValid());

            //Then
            Assert.Equal(expectedValidPasswordsCount, validPasswordsCount);
        }

        [Theory]
        [InlineData(PasswsordsAndPoliciesDescriptionsExample, 1)]
        [InputFileData("Day02/input.txt", 745)]
        public void Count_x_valid_Passwords_with_PositionPolicy(
            string passwsordsAndPoliciesDescriptions,
            int expectedValidPasswordsCount)
        {
            //Given
            var passwordsWithPositionPolicy = PasswsordAndPolicyParser
                .ParsePasswsordsAndPoliciesDescriptions(passwsordsAndPoliciesDescriptions)
                .Select(PasswordFactory.CreatePasswordWithPositionPolicy);

            //When
            var validPasswordsCount = passwordsWithPositionPolicy
                .Count(password => password.IsValid());

            //Then
            Assert.Equal(expectedValidPasswordsCount, validPasswordsCount);
        }
    }
}