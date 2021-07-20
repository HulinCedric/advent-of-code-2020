using Xunit;

namespace AdventOfCode.Day14
{
    public class InitializationProgramInterpreterShould
    {
        [Theory]
        [InlineData("mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X")]
        [InlineData("mask = X11XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", "X11XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX")]
        public void Parse_bitmask(string programInstruction, string expectedBitmaskDescription)
        {
            // Given
            var expectedBitMask = new BitMask(expectedBitmaskDescription);

            // When
            var actualMemory = InitializationProgramInterpreter.Parse(new Memory(), programInstruction);

            // Then
            Assert.Equal(expectedBitMask, actualMemory.BitMask);
        }
    }

    public static class InitializationProgramInterpreter
    {
        public static Memory Parse(Memory memory, string programInstruction)
        {
            if (programInstruction.StartsWith("mask"))
                memory.UpdateBitMask(new BitMask(programInstruction[7..]));

            return memory;
        }
    }
}