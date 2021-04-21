using System.Linq;

namespace AdventOfCode.Day13
{
    public static class NotesParser
    {
        public static Notes Parse(string notesDescription)
        {
            var notesDescriptionLines = notesDescription.Split("\n");
            var earliestDepartureTimestamp = int.Parse(notesDescriptionLines[0]);
            var buses = notesDescriptionLines[1]
                .Split(",")
                .Where(busIdDescription => busIdDescription != "x")
                .Select(int.Parse)
                .Select(busId => new Bus(busId))
                .ToList();
            return new Notes(earliestDepartureTimestamp, buses);
        }
    }
}