using AdventOfCode.Day08.Programs;

namespace AdventOfCode.Day08.Instructions
{
    public class JumpInstruction : Instruction
    {
        public const string OperationName = "jmp";
        
        public JumpInstruction(int argument) :
            base(argument)
        {
        }

        protected override string Operation => OperationName;

        public override InstructionExecutionResult Execute(ProgramContext context)
            => new(
                context.CurrentInstructionIndex + Argument,
                context.AccumulatorValue);
    }
}