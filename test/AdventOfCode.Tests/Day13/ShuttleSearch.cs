using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day13
{
    public class ShuttleSearch
    {
        // [Theory]
        // [InlineData(NotesDescription.Example, 59, 5)]
        // [InputFileData("Day13/input.txt", ?, ?)]
        public void Determine_the_earliest_bus_id_and_the_waiting_minutes_to_take_it(
            string notesDescription,
            int expectedEarliestBusId,
            int expectedWaitingMinutes)
        {
            // Given
            Notes notes = NotesParser.Parse(notesDescription);
            int earliestDepartureTimestamp = notes.EarliestDepartureTimestamp;
            IEnumerable<Bus> buses = notes.Buses;

            // When
            var earliestBusWithNextDepart = buses
                .Select(bus => (bus, nextDepart: bus.GetNextDepartAt(earliestDepartureTimestamp)))
                .OrderBy(busWithNextDepart => busWithNextDepart.nextDepart)
                .First();
            int actualEarliestBusId = earliestBusWithNextDepart.bus.Id;
            int actualWaitingMinutes = earliestBusWithNextDepart.nextDepart - earliestDepartureTimestamp;
            
            // Then
            Assert.Equal(expectedEarliestBusId, actualEarliestBusId);
            Assert.Equal(expectedWaitingMinutes, actualWaitingMinutes);
        }
    }

    public static class NotesParser
    {
        public static Notes Parse(string notesDescription)
        {
            throw new System.NotImplementedException();
        }
    }

    public class Bus
    {
        public int GetNextDepartAt(int fromTimestamp)
        {
            throw new System.NotImplementedException();
        }

        public int Id { get; }
    }

    public class Notes
    {
        public int EarliestDepartureTimestamp { get; }
        public IEnumerable<Bus> Buses { get; }
    }
}