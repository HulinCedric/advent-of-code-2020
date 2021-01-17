using Xunit;

namespace AdventOfCode.Day04.Tests
{
    public class ExpirationYearPassportFieldShould
    {
        [Theory]
        [InlineData("eyr:2020")]
        [InlineData("eyr:2030")]
        public void Be_valid_when_composed_of_four_digits_at_least_2020_and_at_most_2030(string passportFieldDescription)
        {
            var birthYearPassportField = PassportFieldFactory.Create(passportFieldDescription);

            //When
            var birthYearPassportFieldValidty = birthYearPassportField.IsValid();

            //Then
            Assert.True(birthYearPassportFieldValidty);
        }

        [Theory]
        [InlineData("eyr:a")]
        [InlineData("eyr:12a4")]
        [InlineData("eyr:1")]
        [InlineData("eyr:12345")]
        [InlineData("eyr:2019")]
        [InlineData("eyr:2031")]
        public void Be_invalid_for(string passportFieldDescription)
        {
            var birthYearPassportField = PassportFieldFactory.Create(passportFieldDescription);

            //When
            var birthYearPassportFieldValidty = birthYearPassportField.IsValid();

            //Then
            Assert.False(birthYearPassportFieldValidty);
        }
    }
}