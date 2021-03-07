using System;
using Xunit;

namespace AdventOfCode.Day08.Instructions
{
    public class InstructionFactoryShould
    {
        [Theory]
        [InlineData("acc +1", typeof(AccumulatorInstruction))]
        [InlineData("jmp +4", typeof(JumpInstruction))]
        public void Instantiate_instruction_type_corresponding_to_operation_name(
            string instructionDescription,
            Type expectedInstructionType)
        {
            var instruction = InstructionFactory.Create(instructionDescription);

            Assert.IsType(expectedInstructionType, instruction);
        }
    }
}