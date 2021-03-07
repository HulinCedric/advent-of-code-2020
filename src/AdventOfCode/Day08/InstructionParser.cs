namespace AdventOfCode.Day08
{
    public static class InstructionParser
    {
        public static Instruction Parse(string instructionDescription)
            => new(instructionDescription.Split(" ")[0], int.Parse(instructionDescription.Split(" ")[1]));
    }
}