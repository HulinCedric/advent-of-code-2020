using Xunit;

namespace AdventOfCode.Day04.Tests
{
    public class PassportScannerShould
    {
        [Theory]
        [InlineData(BatchFileDescription.PartOneExampleDescription, 2)]
        [InputFileData("Day04/input.txt", 228)]
        public void Count_x_valid_passports(
            string batchFileDescription,
            int expectedValidPassportsCount)
        {
            //When
            var validPassportsCount = PassportScanner.CountValidPassports(batchFileDescription);

            //Then
            Assert.Equal(expectedValidPassportsCount, validPassportsCount);
        }

        [Theory]
        [InlineData(BatchFileDescription.PartTwoInvalidExampleDescription, 0)]
        [InlineData(BatchFileDescription.PartTwoValidExampleDescription, 4)]
        [InputFileData("Day04/input.txt", 175)]
        public void Count_x_valid_passports_with_valid_values(
            string batchFileDescription,
            int expectedValidPassportsCount)
        {
            //When
            var validPassportsCount = PassportScanner.CountValidPassportsWithValidValues(batchFileDescription);

            //Then
            Assert.Equal(expectedValidPassportsCount, validPassportsCount);
        }
    }
}