using Xunit;

namespace AdventOfCode.Day04.Tests
{
    public class PassportShould
    {
        [Fact]
        public void Be_valid_when_all_fields_are_present()
        {
            //Given
            var batchFileDescription = BatchFileDescription.ExampleDescription;
            var expectedPassportValidity = true;
            var passport = new Passport(PassportDescription.First);

            //When
            var passportValidity = passport.IsValid();

            //Then
            Assert.Equal(expectedPassportValidity, passportValidity);
        }

        [Fact]
        public void Be_invalid_when_missing_hgt_field()
        {
            //Given
            var batchFileDescription = BatchFileDescription.ExampleDescription;
            var expectedPassportValidity = false;
            var passport = new Passport(PassportDescription.Second);

            //When
            var passportValidity = passport.IsValid();

            //Then
            Assert.Equal(expectedPassportValidity, passportValidity);
        }

        [Fact]
        public void Be_valid_when_only_missing_cid_field()
        {
            //Given
            var batchFileDescription = BatchFileDescription.ExampleDescription;
            var expectedPassportValidity = true;
            var passport = new Passport(PassportDescription.Third);

            //When
            var passportValidity = passport.IsValid();

            //Then
            Assert.Equal(expectedPassportValidity, passportValidity);
        }

        [Fact]
        public void Be_invalid_when_missing_cid_and_byr_fields()
        {
            //Given
            var batchFileDescription = BatchFileDescription.ExampleDescription;
            var expectedPassportValidity = false;
            var passport = new Passport(PassportDescription.Fourth);

            //When
            var passportValidity = passport.IsValid();

            //Then
            Assert.Equal(expectedPassportValidity, passportValidity);
        }
    }
}