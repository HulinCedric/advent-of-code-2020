using Xunit;

namespace AdventOfCode.Day04.Tests
{
    public class PassportScannerShould
    {
        [Fact]
        public void Count_2_valid_passports_for_example()
        {
            //Given
            var expectedValidPassportsCount = 2;

            //When
            var validPassportsCount = PassportScanner.CountValidPassports(BatchFileDescription.ExampleDescription);

            //Then
            Assert.Equal(expectedValidPassportsCount, validPassportsCount);
        }

        [Fact]
        public void Count_228_valid_passports_for_problem()
        {
            //Given
            var expectedValidPassportsCount = 228;

            //When
            var validPassportsCount = PassportScanner.CountValidPassports(BatchFileDescription.ProblemDescription);

            //Then
            Assert.Equal(expectedValidPassportsCount, validPassportsCount);
        }
    }
}