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
                var switchedInstruction = switchableInstruction switch
                {
                    JumpInstruction => switchableInstruction.SwitchTo<NoOperationInstruction>(),
                    NoOperationInstruction => switchableInstruction.SwitchTo<JumpInstruction>(),
                    _ => switchableInstruction
                };

                var fixedProgramCopy = program.GetCopy();
                fixedProgramCopy.Replace(switchableIndex, switchedInstruction);

                var executionResult = IsolatedProgramRunner.Execute(fixedProgramCopy);
                if (executionResult.IsProgramTerminates)
                    return fixedProgramCopy;
            }

            return program;
        }
    }
}