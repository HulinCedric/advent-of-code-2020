using Xunit;

namespace AdventOfCode.Day09
{
    public class EncodingError
    {
        [Theory]
        [InlineData(PortOutputs.Example, 5, 127)]
        // [InputFileData("Day09/input.txt", 25, 1548)]
        public void Find_the_first_number_that_is_not_the_sum_of_two_preamble_numbers(
            string portOutputs,
            int preambleLength,
            int expectedIntruderNumber)
        {
            // Given
           

            // When
          

            // Then
            Assert.Equal(expectedIntruderNumber, expectedIntruderNumber);
        }
    }
}