namespace AdventOfCode.Day08.Instructions
{
    public class NoOperationInstruction : Instruction
    {
        public NoOperationInstruction(int argument) :
            base(argument)
        {
        }

        public override InstructionExecutionResult Execute(ProgramContext context)
            => new(
                context.CurrentInstructionIndex + 1,
                context.AccumulatorValue);
    }
}