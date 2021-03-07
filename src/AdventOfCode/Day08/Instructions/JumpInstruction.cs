namespace AdventOfCode.Day08.Instructions
{
    public class JumpInstruction : Instruction
    {
        public JumpInstruction(int argument) :
            base(argument)
        {
        }

        public override InstructionExecutionResult Execute(ProgramContext context)
            => new(
                context.CurrentInstructionIndex + Argument,
                context.AccumulatorValue);
    }
}