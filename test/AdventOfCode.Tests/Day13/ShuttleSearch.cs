using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day13
{
    public class ShuttleSearch
    {
        [Theory]
        [InlineData(NotesDescription.Example, 59, 5)]
        [InputFileData("Day13/input.txt", 19, 9)]
        public void Determine_the_earliest_bus_id_and_the_waiting_minutes_to_take_it(
            string notesDescription,
            int expectedEarliestBusId,
            int expectedWaitingMinutes)
        {
            // Given
            var notes = NotesParser.Parse(notesDescription);
            var departureTimestamp = notes.EarliestDepartureTimestamp;
            var buses = notes.Buses;

            // When
            var (earliestBus, nextDepartTimestamp) = buses
                .Select(bus => (bus, nextDepartTimestamp: bus.GetNextDepartTimestamp(departureTimestamp)))
                .OrderBy(busWithNextDepart => busWithNextDepart.nextDepartTimestamp)
                .First();
            var actualEarliestBusId = earliestBus.Id;
            var actualWaitingMinutes = nextDepartTimestamp - departureTimestamp;

            // Then
            Assert.Equal(expectedEarliestBusId, actualEarliestBusId);
            Assert.Equal(expectedWaitingMinutes, actualWaitingMinutes);
        }
    }

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

    public class Bus
    {
        public Bus(int id)
            => Id = id;

        public int Id { get; }

        public int GetNextDepartTimestamp(int timestamp)
            => Id * (timestamp / Id + 1);
    }

    public class Notes
    {
        public Notes(int earliestDepartureTimestamp, List<Bus> buses)
        {
            EarliestDepartureTimestamp = earliestDepartureTimestamp;
            Buses = buses;
        }

        public int EarliestDepartureTimestamp { get; }
        public IEnumerable<Bus> Buses { get; }
    }
}