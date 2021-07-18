using System.Linq;
using Xunit;

namespace AdventOfCode.Day14
{
    public class MaskShould
    {
        [Theory]
        [InlineData(11, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "000000000000000000000000000001001001")]
        [InlineData(101, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "000000000000000000000000000001100101")]
        [InlineData(0, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "000000000000000000000000000001000000")]
        public void Overwrite_memory_value(
            int value,
            string maskDescription,
            string expectedRepresentation)
        {
            // Given
            var memoryValue = new MemoryValue(value);
            var mask = new Mask(maskDescription);

            // When
            var overwrittenMemoryValue = mask.Overwrite(memoryValue);

            // Then
            Assert.Equal(expectedRepresentation, $"{overwrittenMemoryValue}");
        }
    }

    public class Mask
    {
        private readonly string maskDescription;

        public Mask(string maskDescription)
            => this.maskDescription = maskDescription;

        public string Overwrite(MemoryValue memoryValue)
            => string.Concat(
                memoryValue.ToString()
                    .Zip(
                        maskDescription,
                        (memoryValueBit, maskBit) => maskBit == 'X' ? memoryValueBit : maskBit));
    }
}