namespace AdventOfCode.Day13
{
    public class InServiceBus
        : Bus
    {
        public InServiceBus(int id)
            => Id = id;

        /// <summary>
        ///     ID also indicates how often the bus leaves for the airport.
        /// </summary>
        public int Id { get; }

        public long GetNextDepartTimestamp(long timestamp)
            => Id * (timestamp / Id + 1);
    }
}