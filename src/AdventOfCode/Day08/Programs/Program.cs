using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Day08.Instructions;

namespace AdventOfCode.Day08.Programs
{
    public class Program : IEnumerable<Instruction>
    {
        private readonly List<Instruction> instructions;

        public Program(IEnumerable<string> instructionsDescriptions)
            => instructions = instructionsDescriptions.Select(InstructionFactory.Create).ToList();

        public IEnumerator<Instruction> GetEnumerator()
            => instructions.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public Program GetCopy()
            => new(
                instructions
                    .Select(instruction => instruction.ToString())
                    .ToList());

        public void SwitchInstructionAt<T>(int index) where T : Instruction
            => instructions[index] = instructions[index].SwitchTo<T>();
    }
}