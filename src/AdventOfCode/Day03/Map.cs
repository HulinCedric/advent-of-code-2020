using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day03
{
    public class Map
    {
        private IEnumerable<MapLine> lines;

        public Map(string description)
            => lines = Parse(description);

        public IEnumerable<MapLine> Lines => lines;

        public bool GetTreePresenceAt(int lineNumber, int position)
            => lines
            .ElementAt(lineNumber - 1)
            .GetTreePresenceAtPosition(position);

        private static IEnumerable<MapLine> Parse(string mapDescription)
            => mapDescription
            .Split("\n")
            .Select(lineDescription => new MapLine(lineDescription));
    }
}