using Xunit;

namespace AdventOfCode.Day04.Tests
{
    public class EyeColorPassportFieldShould
    {
        [Theory]
        [InlineData("ecl:wat")]
        [InlineData("ecl:zzz")]
        [InlineData("ecl:1")]
        public void Be_invalid_for(string passportFieldDescription)
        {
            //Given
            var passportField = PassportFieldFactory.Create(passportFieldDescription);

            //When
            var passportFieldValidty = passportField.IsValid();

            //Then
            Assert.False(passportFieldValidty);
        }

        [Theory]
        [InlineData("ecl:amb")]
        [InlineData("ecl:blu")]
        [InlineData("ecl:brn")]
        [InlineData("ecl:gry")]
        [InlineData("ecl:grn")]
        [InlineData("ecl:hzl")]
        [InlineData("ecl:oth")]
        public void Be_valid_when_know_eye_color(string passportFieldDescription)
        {
            //Given
            var passportField = PassportFieldFactory.Create(passportFieldDescription);

            //When
            var passportFieldValidty = passportField.IsValid();

            //Then
            Assert.True(passportFieldValidty);
        }
    }
}