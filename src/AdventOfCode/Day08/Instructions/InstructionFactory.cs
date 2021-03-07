using System;

namespace AdventOfCode.Day08.Instructions
{
    public static class InstructionFactory
    {
        public static Instruction Create(string instructionDescription)
        {
            var (operation, argument) = InstructionParser.Parse(instructionDescription);
            return operation switch
            {
                "acc" => new AccumulatorInstruction(argument),
                "jmp" => new JumpInstruction(argument),
                "nop" => new NoOperationInstruction(argument),
                _ => throw new ArgumentException(
                    $"Instruction {operation} is unknown", 
                    nameof(instructionDescription))
            };
        }
    }
}