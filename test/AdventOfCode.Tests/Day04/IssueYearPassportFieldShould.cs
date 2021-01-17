using Xunit;

namespace AdventOfCode.Day04.Tests
{
    public class IssueYearPassportFieldShould
    {
        [Theory]
        [InlineData("iyr:2010")]
        [InlineData("iyr:2020")]
        public void Be_valid_when_composed_of_four_digits_at_least_2010_and_at_most_2020(string passportFieldDescription)
        {
            var birthYearPassportField = PassportFieldFactory.Create(passportFieldDescription);

            //When
            var birthYearPassportFieldValidty = birthYearPassportField.IsValid();

            //Then
            Assert.True(birthYearPassportFieldValidty);
        }

        [Theory]
        [InlineData("iyr:a")]
        [InlineData("iyr:12a4")]
        [InlineData("iyr:1")]
        [InlineData("iyr:12345")]
        [InlineData("iyr:2009")]
        [InlineData("iyr:2021")]
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