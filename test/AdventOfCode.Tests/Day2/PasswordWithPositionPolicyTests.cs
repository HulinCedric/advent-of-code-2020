using Xunit;

namespace AdventOfCode.Day2.Tests
{
    public class PasswordWithPositionPolicyTests
    {
        [Fact]
        public void Invalid_When_Both_Position_2_And_9_Contain_c_ForPassword_ccccccccc()
        {
            //Given
            var passwordPolicy = new PasswordPositionPolicy(2, 9, 'c');
            var password = new Password("ccccccccc", passwordPolicy);
            var expectedPasswordValidity = false;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }

        [Fact]
        public void Invalid_When_Neither_Position_1_Nor_Position_3_Contains_b_ForPassword_cdefg()
        {
            //Given
            var passwordPolicy = new PasswordPositionPolicy(1, 3, 'b');
            var password = new Password("cdefg", passwordPolicy);
            var expectedPasswordValidity = false;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }

        [Fact]
        public void Valid_When_Position_1_Contains_a_And_Position_3_DoesNot()
        {
            //Given
            var passwordPolicy = new PasswordPositionPolicy(1, 3, 'a');
            var password = new Password("abcde", passwordPolicy);
            var expectedPasswordValidity = true;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }
    }
}