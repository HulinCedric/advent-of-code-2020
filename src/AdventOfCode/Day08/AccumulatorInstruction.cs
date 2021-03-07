namespace AdventOfCode.Day08
{
    public class AccumulatorInstruction
    {
        private readonly int argument;

        public AccumulatorInstruction(int argument)
            => this.argument = argument;

        public InstructionExecutionResult Execute(int initialInstructionIndex, int value)
            => new(initialInstructionIndex + 1, value + argument);

        public InstructionExecutionResult Execute(ProgramContext context)
            => new(
                context.CurrentInstructionIndex + 1, 
                context.AccumulatorValue + argument);
    }
}