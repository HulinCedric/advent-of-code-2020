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
            long expectedIntruderNumber)
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
            Assert.Equal(expectedIntruderNumber, currentNumber);
        }
    }
}