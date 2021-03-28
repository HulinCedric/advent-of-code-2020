using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AdventOfCode.Day11
{
    public class SeatingSystem
    {
        [Theory]
        [InlineData(SeatLayoutDescription.Example, 37)]
        [InputFileData("Day11/input.txt", 2277)]
        public void Count_seats_occupied_when_people_stop_moving(
            string seatLayoutDescription,
            int expectedSeatsOccupiedCount)
        {
            // Given
            var seatLayout = SeatLayoutParser.Parse(seatLayoutDescription);
            var nextSeatLayoutSimulation = seatLayout;

            // When
            do
            {
                seatLayout = nextSeatLayoutSimulation;
                nextSeatLayoutSimulation = seatLayout.NextRound();
            } while (nextSeatLayoutSimulation != seatLayout);

            var actualSeatsOccupiedCount = seatLayout.CountOccupiedSeats();

            // Then
            Assert.Equal(expectedSeatsOccupiedCount, actualSeatsOccupiedCount);
        }
    }

    public class SeatLayout
    {
        private readonly int maxColumnIndex;
        private readonly int maxRowIndex;
        private readonly int minColumnIndex = 0;
        private readonly int minRowIndex = 0;
        private readonly string[] seatLayout;

        public SeatLayout(string[] seatLayout)
        {
            this.seatLayout = seatLayout;
            maxRowIndex = seatLayout.Length - 1;
            maxColumnIndex = seatLayout.First().Length - 1;
        }

        public int CountOccupiedSeats()
            => string.Join('\n', seatLayout)
                .Count(seat => seat == '#');

        private IEnumerable<char> GetAdjacentSeatsDescription(int rowIndex, int columnIndex)
        {
            for (var i = rowIndex - 1; i <= rowIndex + 1; i++)
            for (var j = columnIndex - 1; j <= columnIndex + 1; j++)
                if (i >= minRowIndex &&
                    i <= maxRowIndex &&
                    j >= minColumnIndex &&
                    j <= maxColumnIndex &&
                    !(i == rowIndex && j == columnIndex))
                    yield return seatLayout[i][j];
        }

        public SeatLayout NextRound()
        {
            var simulation = new string[seatLayout.Length];
            for (var rowIndex = 0; rowIndex < seatLayout.Length; rowIndex++)
            {
                var seatRow = seatLayout[rowIndex];
                var seatRowBuilder = new StringBuilder();
                for (var columnIndex = 0; columnIndex < seatRow.Length; columnIndex++)
                {
                    var seat = seatRow[columnIndex];
                    var adjacentSeats = GetAdjacentSeatsDescription(rowIndex, columnIndex);
                    var newSeat = seat switch
                    {
                        'L' when adjacentSeats.All(s => s != '#') => '#',
                        '#' when adjacentSeats.Count(s => s == '#') >= 4 => 'L',
                        _ => seat
                    };

                    seatRowBuilder.Append(newSeat);
                }

                simulation[rowIndex] = seatRowBuilder.ToString();
            }

            return new SeatLayout(simulation);
        }

        private bool Equals(SeatLayout other)
            => seatLayout.Zip(other.seatLayout)
                .All(
                    seatsElementsToCompare
                        => Equals(seatsElementsToCompare.First, seatsElementsToCompare.Second));

        public override bool Equals(object obj)
            => obj?.GetType() == GetType() && Equals((SeatLayout) obj);

        public override int GetHashCode()
            => seatLayout != null ? seatLayout.GetHashCode() : 0;

        public static bool operator ==(SeatLayout left, SeatLayout right)
            => Equals(left, right);

        public static bool operator !=(SeatLayout left, SeatLayout right)
            => !Equals(left, right);
    }

    public static class SeatLayoutParser
    {
        public static SeatLayout Parse(string seatLayoutDescription)
            => new(seatLayoutDescription.Split("\n"));
    }
}