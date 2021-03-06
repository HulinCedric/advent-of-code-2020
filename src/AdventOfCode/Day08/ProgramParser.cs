using System;

namespace AdventOfCode.Day08
{
    public static class ProgramParser
    {
        public static Program Parse(string programDescription)
            => new(programDescription.Split("\n", StringSplitOptions.RemoveEmptyEntries));
    }
}