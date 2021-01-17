using Xunit;

namespace AdventOfCode.Day04.Tests
{
    public class PassportScannerShould
    {
        [Fact]
        public void Count_0_valid_passports_with_valid_values_for_example()
        {
            //Given
            var expectedValidPassportsCount = 0;

            //When
            var validPassportsCount = PassportScanner.CountValidPassportsWithValidValues(BatchFileDescription.PartTwoInvalidExampleDescription);

            //Then
            Assert.Equal(expectedValidPassportsCount, validPassportsCount);
        }

        [Fact]
        public void Count_175_valid_passports_with_valid_values_for_problem()
        {
            //Given
            var expectedValidPassportsCount = 175;

            //When
            var validPassportsCount = PassportScanner.CountValidPassportsWithValidValues(BatchFileDescription.ProblemDescription);

            //Then
            Assert.Equal(expectedValidPassportsCount, validPassportsCount);
        }

        [Fact]
        public void Count_2_valid_passports_for_example()
        {
            //Given
            var expectedValidPassportsCount = 2;

            //When
            var validPassportsCount = PassportScanner.CountValidPassports(BatchFileDescription.PartOneExampleDescription);

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

        [Fact]
        public void Count_4_valid_passports_with_valid_values_for_example()
        {
            //Given
            var expectedValidPassportsCount = 4;

            //When
            var validPassportsCount = PassportScanner.CountValidPassportsWithValidValues(BatchFileDescription.PartTwoValidExampleDescription);

            //Then
            Assert.Equal(expectedValidPassportsCount, validPassportsCount);
        }
    }
}