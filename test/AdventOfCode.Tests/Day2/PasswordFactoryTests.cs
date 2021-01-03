using Xunit;

namespace AdventOfCode.Day2.Tests
{
    public class PasswordFactoryTests
    {
        [Fact]
        public void Invalid_When_DescriptionIs_1_3_b_cdefg()
        {
            //Given
            var password = PasswordFactory.CreatePassword("1-3 b: cdefg");
            var expectedPasswordValidity = false;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }

        [Fact]
        public void Valid_When_DescriptionIs_1_3_a_abcde()
        {
            //Given
            var password = PasswordFactory.CreatePassword("1-3 a: abcde");
            var expectedPasswordValidity = true;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }

        [Fact]
        public void Valid_When_DescriptionIs_2_9_c_ccccccccc()
        {
            //Given
            var password = PasswordFactory.CreatePassword("2-9 c: ccccccccc");
            var expectedPasswordValidity = true;

            //When
            var passwordValidity = password.IsValid();

            //Then
            Assert.Equal(expectedPasswordValidity, passwordValidity);
        }
    }
}