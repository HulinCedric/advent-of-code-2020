using Xunit;

namespace AdventOfCode.Day04.PassportFields
{
    public class CountryIdPassportFieldShould
    {
        [Theory]
        [InlineData("cid:000000001")]
        [InlineData("cid:")]
        [InlineData("cid:a")]
        public void Be_always_valid(string passportFieldDescription)
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