using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day03
{
    public class Toboggan
    {
        private const int StartingLineNumber = 1;
        private const int StartingPositon = 1;
        private readonly Map map;
        private readonly Slope slope;

        public Toboggan(Map map)
            : this(map, new Slope(3, 1))
        {
        }

        public Toboggan(Map map, Slope slope)
        {
            this.map = map;
            this.slope = slope;
        }

        public int GetNumberOfTreesEncounteredOnTrajectory()
        {
            var positon = StartingPositon;
            var treesEncountered = 0;
            foreach (var line in GetLinesOnTrajectory())
            {
                positon = GiveNextPosition(positon);
                if (line.GetTreePresenceAtPosition(positon))
                    treesEncountered++;
            }

            return treesEncountered;
        }

        private IEnumerable<MapLine> GetLinesOnTrajectory()
            => map.Lines
            .Skip(StartingLineNumber)
            .Where((_, index) => index % slope.Down == 0);

        private int GiveNextPosition(int positon)
            => positon + slope.Right;
    }
}