using System.Linq;
using AdventOfCode.Day08.Instructions;
using AdventOfCode.Day08.Programs;
using AdventOfCode.Day08.Runners;

namespace AdventOfCode.Day08.Fixers
{
    public static class ProgramFixer
    {
        public static Program Fix(Program program)
        {
            foreach (var (switchableInstruction, switchableIndex) in program
                .Select((instruction, index) => (instruction, index))
                .Where(instructionAndIndex =>
                    instructionAndIndex.instruction is JumpInstruction ||
                    instructionAndIndex.instruction is NoOperationInstruction)
                .ToList())
            {
                var fixedProgram = FixInstruction(program, switchableInstruction, switchableIndex);
                var executionResult = IsolatedProgramRunner.Execute(fixedProgram);
                if (executionResult.IsProgramTerminates)
                    return fixedProgram;
            }

            return program;
        }

        private static Program FixInstruction(
            Program program,
            Instruction instruction,
            int index)
            => instruction switch
            {
                JumpInstruction => program.SwitchInstructionAt<NoOperationInstruction>(index),
                NoOperationInstruction => program.SwitchInstructionAt<JumpInstruction>(index),
                _ => program
            };
    }
}