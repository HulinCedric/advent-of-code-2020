namespace AdventOfCode.Day13
{
    public class Bus
    {
        public Bus(int id)
            => Id = id;

        /// <summary>
        ///     ID also indicates how often the bus leaves for the airport.
        /// </summary>
        public int Id { get; }

        public int GetNextDepartTimestamp(int timestamp)
            => Id * (timestamp / Id + 1);
    }
}