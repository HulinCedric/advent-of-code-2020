using Xunit;

namespace AdventOfCode.Day04.PassportFields
{
    public class PassportIdPassportFieldShould
    {
        [Theory]
        [InlineData("pid:aaaaaaaaa")]
        [InlineData("pid:0123456789")]
        [InlineData("pid:01234567")]
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
        [InlineData("pid:000000001")]
        [InlineData("pid:896056539")]
        public void Be_valid_when_composed_of_nine_digit_number_including_leading_zeroes(string passportFieldDescription)
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