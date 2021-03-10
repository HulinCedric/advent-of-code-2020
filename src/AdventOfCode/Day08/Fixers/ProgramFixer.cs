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
                var fixedProgramCopy = program.GetCopy();
                switch (switchableInstruction)
                {
                    case JumpInstruction:
                        fixedProgramCopy.SwitchInstructionAt<NoOperationInstruction>(switchableIndex);
                        break;
                    case NoOperationInstruction:
                        fixedProgramCopy.SwitchInstructionAt<JumpInstruction>(switchableIndex);
                        break;
                }

                var executionResult = IsolatedProgramRunner.Execute(fixedProgramCopy);
                if (executionResult.IsProgramTerminates)
                    return fixedProgramCopy;
            }

            return program;
        }
    }
}