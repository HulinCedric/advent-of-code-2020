using Xunit;

namespace AdventOfCode.Day04.Tests
{
    public class BirthYearPassportFieldShould
    {
        [Theory]
        [InlineData("byr:2002")]
        [InlineData("byr:1920")]
        public void Be_valid_when_composed_of_four_digits_at_least_1920_and_at_most_2002(string passportFieldDescription)
        {
            var birthYearPassportField = PassportFieldFactory.Create(passportFieldDescription);

            //When
            var birthYearPassportFieldValidty = birthYearPassportField.IsValid();

            //Then
            Assert.True(birthYearPassportFieldValidty);
        }

        [Theory]
        [InlineData("byr:a")]
        [InlineData("byr:12a4")]
        [InlineData("byr:1")]
        [InlineData("byr:12345")]
        [InlineData("byr:2003")]
        [InlineData("byr:1919")]
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