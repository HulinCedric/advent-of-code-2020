using Xunit;

namespace AdventOfCode.Day04.Tests
{
    public class PassportShould
    {
        [Fact]
        public void Be_valid_when_all_fields_are_present()
        {
            //Given
            var passport = PassportFactory.Create(PassportDescription.First);
            var expectedPassportValidity = true;

            //When
            var passportValidity = passport.IsValid();

            //Then
            Assert.Equal(expectedPassportValidity, passportValidity);
        }

        [Fact]
        public void Be_invalid_when_missing_hgt_field()
        {
            //Given
            var passport = PassportFactory.Create(PassportDescription.Second);
            var expectedPassportValidity = false;

            //When
            var passportValidity = passport.IsValid();

            //Then
            Assert.Equal(expectedPassportValidity, passportValidity);
        }

        [Fact]
        public void Be_valid_when_only_missing_cid_field()
        {
            //Given
            var passport = PassportFactory.Create(PassportDescription.Third);
            var expectedPassportValidity = true;

            //When
            var passportValidity = passport.IsValid();

            //Then
            Assert.Equal(expectedPassportValidity, passportValidity);
        }

        [Fact]
        public void Be_invalid_when_missing_cid_and_byr_fields()
        {
            //Given
            var passport = PassportFactory.Create(PassportDescription.Fourth);
            var expectedPassportValidity = false;

            //When
            var passportValidity = passport.IsValid();

            //Then
            Assert.Equal(expectedPassportValidity, passportValidity);
        }
    }
}