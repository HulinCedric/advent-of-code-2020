using Xunit;

namespace AdventOfCode.Day13
{
    public class ShuttleSearch
    {
        [Theory]
        [InlineData(NotesDescription.Example, 59, 5)]
        // [InputFileData("Day13/input.txt", ?, ?)]
        public void Determine_the_earliest_bus_id_and_the_waiting_minutes_to_take_it(
            string notesDescription,
            int earliestBusId,
            int waitingMinutes)
        {
            // Given

            // When

            // Then
            Assert.Equal(earliestBusId, earliestBusId);
            Assert.Equal(waitingMinutes, waitingMinutes);
        }
    }
}