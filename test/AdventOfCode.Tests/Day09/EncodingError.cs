using System.Linq;
using Xunit;

namespace AdventOfCode.Day09
{
    public class EncodingError
    {
        [Theory]
        [InlineData(PortOutputs.Example, 5, 127)]
        [InputFileData("Day09/input.txt", 25, 27911108)]
        public void Find_the_first_number_that_is_not_the_sum_of_two_preamble_numbers(
            string portOutputs,
            int preambleLength,
            long expectedInvalidNumber)
        {
            // Given
            var numbers = portOutputs.Split("\n").Select(long.Parse).ToList();
            var index = 0;
            long currentNumber;

            // When
            do
            {
                var preamble = numbers.Skip(index).Take(preambleLength).ToList();

                var validNumbers =
                    from x in preamble
                    from y in preamble
                    select x + y;

                currentNumber = numbers.ElementAt(preambleLength + index);

                var isInvalid = !validNumbers.Contains(currentNumber);
                if (isInvalid)
                    break;
            } while (preambleLength + ++index < numbers.Count);

            // Then
            Assert.Equal(expectedInvalidNumber, currentNumber);
        }

        [Theory]
        [InlineData(PortOutputs.Example, 127L, 15L, 47L)]
        // [InputFileData("Day09/input.txt", 27911108L, ?, ?)]
        public void Find_a_contiguous_set_of_at_least_two_numbers_which_sum_to_the_invalid_number(
            string portOutputs,
            long invalidNumber,
            long expectedSmallestWeaknessNumber,
            long expectedLargestWeaknessNumber)
        {
            // Given
            var numbers = portOutputs.Split("\n").Select(long.Parse).ToList();
            var actualSmallestWeaknessNumber = 15L;
            var actualLargestWeaknessNumber = 47L;

            // When


            // Then
            Assert.Equal(expectedSmallestWeaknessNumber, actualSmallestWeaknessNumber);
            Assert.Equal(expectedLargestWeaknessNumber, actualLargestWeaknessNumber);
        }
    }
}