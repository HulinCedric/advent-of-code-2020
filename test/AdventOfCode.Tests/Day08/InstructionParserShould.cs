using Xunit;

namespace AdventOfCode.Day08
{
    public class InstructionParserShould
    {
        [Theory]
        [InlineData("nop +0", "nop", 0)]
        [InlineData("acc +1", "acc", 1)]
        [InlineData("jmp +4", "jmp", 4)]
        [InlineData("acc -99", "acc", -99)]
        public void Parse_operation_and_argument_split_by_a_space(
            string instructionDescription,
            string expectedOperationDescription,
            int expectedArgumentDescription)
        {
            var instruction = InstructionParser.Parse(instructionDescription);

            Assert.Equal(instruction.Operation, expectedOperationDescription);
            Assert.Equal(instruction.Argument, expectedArgumentDescription);
        }
    }
}