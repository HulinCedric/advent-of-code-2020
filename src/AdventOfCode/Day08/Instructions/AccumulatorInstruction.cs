namespace AdventOfCode.Day08.Instructions
{
    public class AccumulatorInstruction : Instruction
    {
        public AccumulatorInstruction(int argument) :
            base(argument)
        {
        }

        public override InstructionExecutionResult Execute(ProgramContext context)
            => new(
                context.CurrentInstructionIndex + 1,
                context.AccumulatorValue + Argument);
    }
}