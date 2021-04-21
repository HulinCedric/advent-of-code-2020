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
}