using AdventOfCode.Day08.Programs;

namespace AdventOfCode.Day08.Instructions
{
    public class NoOperationInstruction : Instruction
    {
        public const string OperationName = "nop";

        public NoOperationInstruction(int argument) :
            base(argument)
        {
        }

        protected override string Operation => OperationName;

        public override InstructionExecutionResult Execute(ProgramContext context)
            => new(
                context.CurrentInstructionIndex + 1,
                context.AccumulatorValue);
    }
}