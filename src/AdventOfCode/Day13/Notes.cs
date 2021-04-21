using System.Collections.Generic;

namespace AdventOfCode.Day13
{
    public class Notes
    {
        public Notes(int earliestDepartureTimestamp, List<Bus> buses)
        {
            EarliestDepartureTimestamp = earliestDepartureTimestamp;
            Buses = buses;
        }

        public IEnumerable<Bus> Buses { get; }

        public int EarliestDepartureTimestamp { get; }
    }
}