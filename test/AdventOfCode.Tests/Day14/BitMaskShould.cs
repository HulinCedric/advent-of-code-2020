using System.Linq;
using Xunit;

namespace AdventOfCode.Day14
{
    public class BitMaskShould
    {
        [Fact]
        public void Have_a_default_value()
        {
            // Given
            var expectedMask = new BitMask("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

            // When
            var actualMask = BitMask.Default;

            // Then
            Assert.Equal(expectedMask, actualMask);
        }

        [Theory]
        [InlineData(11, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "000000000000000000000000000001001001")]
        [InlineData(101, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "000000000000000000000000000001100101")]
        [InlineData(0, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "000000000000000000000000000001000000")]
        public void Overwrite_memory_value(
            long value,
            string maskDescription,
            string expectedRepresentation)
        {
            // Given
            var expectedMemoryValue = new MemoryValue(expectedRepresentation);
            var memoryValue = new MemoryValue(value);
            var mask = new BitMask(maskDescription);

            // When
            var overwrittenMemoryValue = mask.Overwrite(memoryValue);

            // Then
            Assert.Equal(expectedMemoryValue, overwrittenMemoryValue);
        }
    }

    public record BitMask
    {
        private readonly string bitMaskDescription;

        public BitMask(string bitMaskDescription)
            => this.bitMaskDescription = bitMaskDescription;

        public static BitMask Default
            => new("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

        public MemoryValue Overwrite(MemoryValue memoryValue)
            => new(string.Concat(
                memoryValue.ToString()
                    .Zip(
                        bitMaskDescription,
                        (memoryValueBit, maskBit) => maskBit == 'X' ? memoryValueBit : maskBit)));
    }
}