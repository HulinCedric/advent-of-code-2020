using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Day14
{
    public class MemoryShould
    {
        [Fact]
        public void Get_value()
        {
            // Given
            var memory = new Memory();
            var expectedMemoryValue = new MemoryValue(11);
            memory.WriteAt(8, 11);

            // When
            var actualMemoryValue = memory.ValueAt(8);

            // Then
            Assert.Equal(expectedMemoryValue, actualMemoryValue);
        }

        [Fact]
        public void Overwrite_value()
        {
            // Given
            var memory = new Memory();

            // When
            memory.WriteAt(8, 11);
            memory.WriteAt(8, 12);

            // Then
            Assert.NotEmpty(memory.Values);
            Assert.Equal(1, memory.Values.Count);
        }

        [Fact]
        public void Update_bitmask()
        {
            // Given
            var memory = new Memory();
            var expectedMask = new Mask("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X");

            // When
            memory.UpdateBitMask(expectedMask);

            // Then
            Assert.Equal(expectedMask, memory.BitMask);
        }

        [Fact]
        public void Write_value()
        {
            // Given
            var memory = new Memory();

            // When
            memory.WriteAt(8, 11);
            memory.WriteAt(8, 12);

            // Then
            Assert.NotEmpty(memory.Values);
            Assert.Equal(1, memory.Values.Count);
        }
    }

    public class Memory
    {
        private readonly Dictionary<int, MemoryValue> values = new();

        public Memory()
            => BitMask = Mask.Default;

        public Mask BitMask { get; private set; }

        public IReadOnlyCollection<MemoryValue> Values
            => values.Values;

        public void UpdateBitMask(Mask mask)
            => BitMask = mask;

        public MemoryValue ValueAt(int position)
            => values[position];

        public void WriteAt(int position, int value)
            => values[position] = new MemoryValue(value);
    }
}