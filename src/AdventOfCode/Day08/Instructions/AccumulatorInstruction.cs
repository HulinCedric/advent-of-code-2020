﻿using AdventOfCode.Day08.Programs;

namespace AdventOfCode.Day08.Instructions
{
    public class AccumulatorInstruction : Instruction
    {
        public const string OperationName = "acc";

        public AccumulatorInstruction(int argument) :
            base(argument)
        {
        }

        protected override string Operation => OperationName;

        public override InstructionExecutionResult Execute(ProgramContext context)
            => new(
                context.CurrentInstructionIndex + 1,
                context.AccumulatorValue + Argument);
    }
}