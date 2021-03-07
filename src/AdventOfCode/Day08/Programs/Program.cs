using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Day08.Instructions;

namespace AdventOfCode.Day08.Programs
{
    public class Program : IEnumerable<Instruction>
    {
        private readonly IEnumerable<Instruction> instructionsDescriptions;

        public Program(IEnumerable<string> instructionsDescriptions)
            => this.instructionsDescriptions = instructionsDescriptions.Select(InstructionFactory.Create);

        public IEnumerator<Instruction> GetEnumerator()
            => instructionsDescriptions.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}