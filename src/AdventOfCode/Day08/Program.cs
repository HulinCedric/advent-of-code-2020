using System.Collections;
using System.Collections.Generic;

namespace AdventOfCode.Day08
{
    public class Program : IEnumerable<string>
    {
        private readonly IEnumerable<string> instructionsDescriptions;

        public Program(IEnumerable<string> instructionsDescriptions)
            => this.instructionsDescriptions = instructionsDescriptions;

        public IEnumerator<string> GetEnumerator()
            => instructionsDescriptions.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}