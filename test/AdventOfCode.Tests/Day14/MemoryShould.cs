using System.Collections.Generic;
using System.Linq;
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
        public void Sum_all_values()
        {
            // Given
            var memory = new Memory();

            var mask = new BitMask("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X");

            memory.UpdateBitMask(mask);

            memory.WriteAt(8, 11);
            memory.WriteAt(7, 101);
            memory.WriteAt(8, 0);

            var expectedSumMemoryValue = new MemoryValue(165);

            // When
            var actualSumMemoryValue = memory.Sum;

            // Then
            Assert.Equal(expectedSumMemoryValue, actualSumMemoryValue);
        }

        [Fact]
        public void Update_bitmask()
        {
            // Given
            var memory = new Memory();
            var expectedMask = new BitMask("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X");

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
            memory.WriteAt(8, 8);

            // Then
            Assert.NotEmpty(memory.Values);
            Assert.Equal(1, memory.Values.Count);
        }

        [Theory]
        [InlineData(11, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "000000000000000000000000000001001001")]
        [InlineData(101, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "000000000000000000000000000001100101")]
        [InlineData(0, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "000000000000000000000000000001000000")]
        public void Write_value_with_bitmask_overwrite_value(
            long value,
            string maskDescription,
            string expectedRepresentation)
        {
            // Given
            var memory = new Memory();
            memory.UpdateBitMask(new BitMask(maskDescription));
            var expectedMemoryValue = new MemoryValue(expectedRepresentation);

            // When
            memory.WriteAt(1, value);

            // Then
            Assert.Equal(expectedMemoryValue, memory.ValueAt(1));
        }
    }

    public class Memory
    {
        private readonly Dictionary<uint, MemoryValue> values = new();

        public Memory()
            => BitMask = BitMask.Default;

        public BitMask BitMask { get; private set; }

        public MemoryValue Sum
            => values.Values.Aggregate(
                new MemoryValue(0),
                (acc, current) => acc + current);

        public IReadOnlyCollection<MemoryValue> Values
            => values.Values;

        public void UpdateBitMask(BitMask bitMask)
            => BitMask = bitMask;

        public MemoryValue ValueAt(uint position)
            => values[position];

        public void WriteAt(uint position, long value)
            => values[position] = BitMask.Overwrite(new MemoryValue(value));
    }
}