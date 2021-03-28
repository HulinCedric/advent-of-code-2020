using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day11
{
    public class SeatingSystem
    {
        [Theory]
        [InlineData(SeatLayoutDescription.Example, 37)]
        // [InputFileData("Day11/input.txt", 37)]
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
                nextSeatLayoutSimulation = PeopleSeatChoiceSimulator.Simulate(seatLayout);
            } while (!nextSeatLayoutSimulation.Equals(seatLayout));

            var actualSeatsOccupiedCount = seatLayout.CountOccupiedSeats();

            // Then
            Assert.Equal(expectedSeatsOccupiedCount, actualSeatsOccupiedCount);
        }
    }

    public static class PeopleSeatChoiceSimulator
    {
        public static SeatLayout Simulate(SeatLayout seatLayout)
            => seatLayout.With(SimulateAndGetSeatTopology(seatLayout));

        private static IEnumerable<Seat> SimulateAndGetSeatTopology(SeatLayout seatLayout)
            => from seat in seatLayout
                let adjacentSeats = seatLayout.GetAdjacentSeats(seat)
                select seat.State switch
                {
                    SeatState.Empty when adjacentSeats.All(seat => seat.State != SeatState.Occupied) => seat with
                    {
                        State = SeatState.Occupied
                    },
                    SeatState.Occupied when adjacentSeats.Count(seat => seat.State == SeatState.Occupied) >= 4
                        => seat with
                        {
                            State = SeatState.Empty
                        },
                    _ => seat
                };
    }

    public record Seat : SeatLayoutElement
    {
        private Seat(int x, int y, SeatState state)
            : base(x, y)
            => State = state;

        public SeatState State { get; init; }

        public static Seat Occupied(int x, int y)
            => new(x, y, SeatState.Occupied);

        public static Seat Empty(int x, int y)
            => new(x, y, SeatState.Empty);
    }

    public enum SeatState
    {
        Empty,
        Occupied
    }

    public record Floor : SeatLayoutElement
    {
        public Floor(int x, int y)
            : base(x, y)
        {
        }
    }

    public abstract record SeatLayoutElement
    {
        protected SeatLayoutElement(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        internal static SeatLayoutElement Create(int x, int y, char seatLayoutElementDescription)
        {
            return seatLayoutElementDescription switch
            {
                'L' => Seat.Empty(x, y),
                '#' => Seat.Occupied(x, y),
                '.' => new Floor(x, y),
                _ => null
            };
        }
    }


    public class SeatLayout
        : IEnumerable<Seat>
    {
        private readonly List<SeatLayoutElement> seatLayout;

        public SeatLayout(List<SeatLayoutElement> seatLayout)
            => this.seatLayout = seatLayout;

        public IEnumerator<Seat> GetEnumerator()
            => seatLayout.OfType<Seat>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public int CountOccupiedSeats()
            => seatLayout
                .OfType<Seat>()
                .Count(seat => seat.State == SeatState.Occupied);

        public IEnumerable<Seat> GetAdjacentSeats(Seat seat)
        {
            var seats = seatLayout.OfType<Seat>().ToList();
            if (seats.FirstOrDefault(s => s.X == seat.X - 1 && s.Y == seat.Y) is var upperSeat &&
                upperSeat is not null)
                yield return upperSeat;

            if (seats.FirstOrDefault(s => s.X == seat.X + 1 && s.Y == seat.Y) is var downSeat &&
                downSeat is not null)
                yield return downSeat;

            if (seats.FirstOrDefault(s => s.X == seat.X && s.Y == seat.Y + 1) is var rightSeat &&
                rightSeat is not null)
                yield return rightSeat;

            if (seats.FirstOrDefault(s => s.X == seat.X && s.Y == seat.Y - 1) is var leftSeat &&
                leftSeat is not null)
                yield return leftSeat;

            if (seats.FirstOrDefault(s => s.X == seat.X + 1 && s.Y == seat.Y - 1) is var upRightSeat &&
                upRightSeat is not null)
                yield return upRightSeat;

            if (seats.FirstOrDefault(s => s.X == seat.X + 1 && s.Y == seat.Y + 1) is var downRightSeat &&
                downRightSeat is not null)
                yield return downRightSeat;

            if (seats.FirstOrDefault(s => s.X == seat.X - 1 && s.Y == seat.Y - 1) is var upLeftSeat &&
                upLeftSeat is not null)
                yield return upLeftSeat;

            if (seats.FirstOrDefault(s => s.X == seat.X - 1 && s.Y == seat.Y + 1) is var downLeftSeat &&
                downLeftSeat is not null)
                yield return downLeftSeat;
        }

        private bool Equals(SeatLayout other)
            => seatLayout.Zip(other.seatLayout)
                .All(
                    seatsElementsToCompare
                        => Equals(seatsElementsToCompare.First, seatsElementsToCompare.Second));

        public override bool Equals(object obj)
            => obj.GetType() == GetType() && Equals((SeatLayout) obj);

        public override int GetHashCode()
            => seatLayout != null ? seatLayout.GetHashCode() : 0;

        public static bool operator ==(SeatLayout left, SeatLayout right)
            => Equals(left, right);

        public static bool operator !=(SeatLayout left, SeatLayout right)
            => !Equals(left, right);

        public SeatLayout With(IEnumerable<Seat> seatTopology)
            => new(ReplaceMatchingSeatElement(seatTopology).ToList());

        private IEnumerable<SeatLayoutElement> ReplaceMatchingSeatElement(IEnumerable<Seat> seatDescription)
        {
            foreach (var seatLayoutElement in seatLayout)
                if (seatDescription.FirstOrDefault(s => s.X == seatLayoutElement.X && s.Y == seatLayoutElement.Y) is var
                        matchingSeat &&
                    matchingSeat is not null)
                    yield return matchingSeat;
                else
                    yield return seatLayoutElement;
        }
    }

    public static class SeatLayoutParser
    {
        public static SeatLayout Parse(string seatLayoutDescription)
            => new(ParseAndConvert(seatLayoutDescription).ToList());

        private static IEnumerable<SeatLayoutElement> ParseAndConvert(string seatLayoutDescription)
        {
            var seatRows = seatLayoutDescription.Split("\n");
            for (var seatIndex = 0; seatIndex < seatRows.Length; seatIndex++)
            {
                var seatRow = seatRows[seatIndex];
                for (var seatColumnIndex = 0; seatColumnIndex < seatRow.Length; seatColumnIndex++)
                {
                    var seatLayoutItemDescription = seatRow[seatColumnIndex];
                    yield return SeatLayoutElement.Create(seatIndex, seatColumnIndex, seatLayoutItemDescription);
                }
            }
        }
    }
}