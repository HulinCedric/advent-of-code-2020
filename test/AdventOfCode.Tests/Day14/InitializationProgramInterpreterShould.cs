using System;
using Xunit;

namespace AdventOfCode.Day14
{
    public class InitializationProgramInterpreterShould
    {
        [Theory]
        [InlineData("mem[8] = 11", 8, 11)]
        [InlineData("mem[7] = 101", 7, 101)]
        public void Read_set_memory_instruction(string programInstruction, uint memoryPosition, long value)
        {
            // Given
            var expectedMemoryValue = new MemoryValue(value);

            // When
            var actualMemory = InitializationProgramInterpreter.Read(new Memory(), programInstruction);
            var actualMemoryValue = actualMemory.ValueAt(memoryPosition);

            // Then
            Assert.Equal(expectedMemoryValue, actualMemoryValue);
        }

        [Theory]
        [InlineData("mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X")]
        [InlineData("mask = X11XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "X11XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")]
        public void Read_update_bitmask_instruction(string programInstruction, string expectedBitmaskDescription)
        {
            // Given
            var expectedBitMask = new BitMask(expectedBitmaskDescription);

            // When
            var actualMemory = InitializationProgramInterpreter.Read(new Memory(), programInstruction);

            // Then
            Assert.Equal(expectedBitMask, actualMemory.BitMask);
        }
    }

    public static class InitializationProgramInterpreter
    {
        public static Memory Read(Memory memory, string programInstruction)
        {
            if (programInstruction.StartsWith("mask"))
                memory.UpdateBitMask(new BitMask(programInstruction[7..]));

            if (programInstruction.StartsWith("mem"))
            {
                var position = ExtractPosition(programInstruction);
                var value = ExtractValue(programInstruction);
                memory.WriteAt(position, value);
            }

            return memory;
        }

        private static uint ExtractPosition(string programInstruction)
        {
            const int startIndex = 4;
            var endIndex = programInstruction.IndexOf(']');
            var rawPosition = programInstruction[startIndex..endIndex];
            return uint.Parse(rawPosition.Trim());
        }

        private static uint ExtractValue(string programInstruction)
        {
            var startIndex = programInstruction.IndexOf("= ", StringComparison.Ordinal) + 2;
            var rawValue = programInstruction[startIndex..];
            return uint.Parse(rawValue.Trim());
        }
    }
}