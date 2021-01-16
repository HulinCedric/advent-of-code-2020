using Xunit;

namespace AdventOfCode.Day04.Tests
{
    public class PassportFieldFactoryShould
    {
        [Fact]
        public void Create_a_birth_year_passport_field_for_passport_field_description()
        {
            //Given
            var passportFieldDescription = "byr:2002";
            var expectedPassportFieldType = typeof(BirthYearPassportField);

            //When
            var passportField = PassportFieldFactory.Create(passportFieldDescription);

            //Then
            Assert.IsType(expectedPassportFieldType, passportField);
        }

    }
}