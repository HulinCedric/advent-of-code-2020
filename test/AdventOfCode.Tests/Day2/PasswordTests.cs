using Xunit;

namespace AdventOfCode.Day2.Tests
{
    public class PasswordTests
    {
        [Fact]
        public void Invalid_When_AtLeast_1_And_AtMost_3_Charater_b_ForPassword_cdefg()
        {
            //Given
            var passwordPolicy = new PasswordPolicy(1, 3, 'b');
            var password = new Password("cdefg", passwordPolicy);
            var expectedPasswordValidity = false;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }

        [Fact]
        public void Valid_When_AtLeast_1_And_AtMost_3_Charater_a_ForPassword_abcde()
        {
            //Given
            var passwordPolicy = new PasswordPolicy(1, 3, 'a');
            var password = new Password("abcde", passwordPolicy);
            var expectedPasswordValidity = true;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }

        [Fact]
        public void Valid_When_AtLeast_2_And_AtMost_9_Charater_c_ForPassword_ccccccccc()
        {
            //Given
            var passwordPolicy = new PasswordPolicy(2, 9, 'c');
            var password = new Password("ccccccccc", passwordPolicy);
            var expectedPasswordValidity = true;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }
    }
}