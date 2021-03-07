using AdventOfCode.Day08.Programs;

namespace AdventOfCode.Day08.Instructions
{
    public abstract class Instruction
    {
        protected Instruction(int argument)
            => Argument = argument;


        protected int Argument { get; }
        
        protected abstract string Operation { get; }

        public abstract InstructionExecutionResult Execute(ProgramContext context);

        public override string ToString() => $"{Operation} {(Argument >= 0 ? '+' : string.Empty)}{Argument}";
    }
}