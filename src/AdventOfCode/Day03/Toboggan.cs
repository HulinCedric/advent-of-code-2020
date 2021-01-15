using System.Linq;

namespace AdventOfCode.Day03
{
    public class Toboggan
    {
        private readonly Map map;

        public Toboggan(Map map)
            => this.map = map;

        public int GetNumberOfTreesEncounteredOnTrajectory()
        {
            var startingLineNumber = 1;
            var positon = 1;
            var treesEncountered = 0;
            foreach (var line in map.Lines.Skip(startingLineNumber))
            {
                positon = GiveNextPosition(positon);
                if (line.GetTreePresenceAtPosition(positon))
                    treesEncountered++;
            }

            return treesEncountered;
        }

        private static int GiveNextPosition(int positon)
            => positon + 3;
    }
}