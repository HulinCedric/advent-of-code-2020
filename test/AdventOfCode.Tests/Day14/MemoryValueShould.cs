using System;
using Xunit;

namespace AdventOfCode.Day14
{
    public class MemoryValueShould
    {
        [Theory]
        [InlineData("000000000000000000000000000000001011", 11)]
        [InlineData("000000000000000000000000000001100101", 101)]
        [InlineData("000000000000000000000000000000000000", 0)]
        public void Be_construct_through_representation(
            string memoryValueRepresentation,
            int expectedValue)
        {
            // Given
            var expectedMemoryValue = new MemoryValue(expectedValue);

            // When
            var actualMemoryValue = new MemoryValue(memoryValueRepresentation);

            // Then
            Assert.Equal(expectedMemoryValue, actualMemoryValue);
        }

        [Theory]
        [InlineData(11, "000000000000000000000000000000001011")]
        [InlineData(101, "000000000000000000000000000001100101")]
        [InlineData(0, "000000000000000000000000000000000000")]
        public void Be_represented_on_36bits(
            int value,
            string expectedRepresentation)
        {
            // Given

            // When
            var memValue = new MemoryValue(value);

            // Then
            Assert.Equal(expectedRepresentation, $"{memValue}");
        }
    }

    public record MemoryValue
    {
        private readonly string representation;
        private readonly int value;

        public MemoryValue(string representation)
        {
            this.representation = representation;
            value = Convert.ToInt32(representation, 2);
        }

        public MemoryValue(int value)
        {
            this.value = value;
            representation = Convert.ToString(value, 2)
                .PadLeft(36, '0');
        }

        public override string ToString()
            => representation;
    }
}