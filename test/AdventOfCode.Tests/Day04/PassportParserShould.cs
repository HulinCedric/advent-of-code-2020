using System.Linq;
using AdventOfCode.Day04.Inputs;
using Xunit;

namespace AdventOfCode.Day04
{
    public class PassportParserShould
    {
        [Fact]
        public void Give_passeports_separate_by_blank_lines()
        {
            //Given
            var batchFileDescription = BatchFileDescription.PartOneExampleDescription;
            var expectedPassportsCount = 4;

            //When
            var passportsCount = PassportParser.ParseBatchFile(batchFileDescription).Count();

            //Then
            Assert.Equal(expectedPassportsCount, passportsCount);
        }

        [Theory]
        [InlineData(0, 8)]
        [InlineData(1, 7)]
        [InlineData(2, 7)]
        [InlineData(3, 6)]
        public void Give_passeport_fields_separate_by_spaces_or_newlines(int passportNumber, int expectedPassportFieldsCount)
        {
            //Given
            var batchFileDescription = BatchFileDescription.PartOneExampleDescription;

            //When
            var passportFieldsCount = PassportParser.ParsePassportDescription(
                PassportParser
                .ParseBatchFile(batchFileDescription)
                .ElementAt(passportNumber)).Count();

            //Then
            Assert.Equal(expectedPassportFieldsCount, passportFieldsCount);
        }

        [Theory]
        [InlineData("byr:2002", "byr", "2002")]
        [InlineData("hgt:190in", "hgt", "190in")]
        public void Give_passeport_field_informations_separate_by_colon(
            string passportFieldDescription,
            string expectedPassportFieldName,
            string expectedPassportFieldValue)
        {
            //When
            var passportFieldInformations = PassportParser.ParsePassportFieldDescription(passportFieldDescription);

            //Then
            Assert.Equal(expectedPassportFieldName, passportFieldInformations.Name);
            Assert.Equal(expectedPassportFieldValue, passportFieldInformations.Value);
        }
    }
}