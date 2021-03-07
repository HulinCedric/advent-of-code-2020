namespace AdventOfCode.Day08.Instructions
{
    public abstract class Instruction
    {
        protected Instruction(int argument)
            => Argument = argument;

        protected int Argument { get; }

        public abstract InstructionExecutionResult Execute(ProgramContext context);
    }
}