using System.Linq;

namespace AdventOfCode.Day03
{
    public class MapLine
    {
        private readonly string description;

        public MapLine(string description)
            => this.description = description;

        public char GetElementDescriptionAtPosition(int position)
            => description.ElementAt(GetIndexForPosition(position));

        private int GetIndexForPosition(int position)
            => GetIndexWithPatternRepeats(position - 1);

        private int GetIndexWithPatternRepeats(int index)
            => index % description.Length;
    }
}