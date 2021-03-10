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
            => this.instructions = instructionsDescriptions.Select(InstructionFactory.Create).ToList();

        public IEnumerator<Instruction> GetEnumerator()
            => instructions.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public Program GetCopy()
            => new Program(instructions.Select(instruction=>instruction.ToString()).ToList());

        public int Count
            => instructions.Count;
        
        public int IndexOf(Instruction instruction)
            => instructions.IndexOf(instruction);

        public void Replace(int index, Instruction instruction)
            => instructions[index] = instruction;
    }
}