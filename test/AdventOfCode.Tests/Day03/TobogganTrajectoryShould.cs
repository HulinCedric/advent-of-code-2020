using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day03.Tests
{
    public class TobogganTrajectoryShould
    {
        [Fact]
        public void Encounter_189_trees_for_problem()
        {
            //Given
            var toboggan = new Toboggan(new Map(MapDescription.ProblemDescription));
            var expectedNumberOfTreesEncountered = 189;

            //When
            var numberOfTreesEncountered = toboggan.GetNumberOfTreesEncounteredOnTrajectory();

            //Then
            Assert.Equal(expectedNumberOfTreesEncountered, numberOfTreesEncountered);
        }

        [Fact]
        public void Encounter_7_trees_for_example()
        {
            //Given
            var toboggan = new Toboggan(new Map(MapDescription.ExampleDescription));
            var expectedNumberOfTreesEncountered = 7;

            //When
            var numberOfTreesEncountered = toboggan.GetNumberOfTreesEncounteredOnTrajectory();

            //Then
            Assert.Equal(expectedNumberOfTreesEncountered, numberOfTreesEncountered);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(3, 1, 7)]
        [InlineData(5, 1, 3)]
        [InlineData(7, 1, 4)]
        [InlineData(1, 2, 2)]
        public void Encounter_trees_with_slope_for_example(
            int right,
            int down,
            int expectedNumberOfTreesEncountered)
        {
            //Given
            var toboggan = new Toboggan(
                new Map(MapDescription.ExampleDescription),
                new Slope(right, down));

            //When
            var numberOfTreesEncountered = toboggan.GetNumberOfTreesEncounteredOnTrajectory();

            //Then
            Assert.Equal(expectedNumberOfTreesEncountered, numberOfTreesEncountered);
        }

        [Theory]
        [InlineData(1, 1, 74)]
        [InlineData(3, 1, 189)]
        [InlineData(5, 1, 65)]
        [InlineData(7, 1, 63)]
        [InlineData(1, 2, 30)]
        public void Encounter_trees_with_slope_for_problem(
            int right,
            int down,
            int expectedNumberOfTreesEncountered)
        {
            //Given
            var toboggan = new Toboggan(
                new Map(MapDescription.ProblemDescription),
                new Slope(right, down));

            //When
            var numberOfTreesEncountered = toboggan.GetNumberOfTreesEncounteredOnTrajectory();

            //Then
            Assert.Equal(expectedNumberOfTreesEncountered, numberOfTreesEncountered);
        }

        [Fact]
        public void Encounter_336_multiplied_trees_with_range_of_toboggans_for_example()
        {
            //Given
            var map = new Map(MapDescription.ExampleDescription);
            var toboggans = new List<Toboggan>
            {
                new Toboggan(map, new Slope(1, 1)),
                new Toboggan(map, new Slope(3, 1)),
                new Toboggan(map, new Slope(5, 1)),
                new Toboggan(map, new Slope(7, 1)),
                new Toboggan(map, new Slope(1, 2)),
            };

            //When
            var multipliedNumberOfTreesEncountered = toboggans
            .Select(toboggan => toboggan.GetNumberOfTreesEncounteredOnTrajectory())
            .Aggregate(1L, (a, b) => a * b);

            //Then
            Assert.Equal(336L, multipliedNumberOfTreesEncountered);
        }

        [Fact]
        public void Encounter_1718180100_multiplied_trees_with_range_of_toboggans_for_problem()
        {
            //Given
            var map = new Map(MapDescription.ProblemDescription);
            var toboggans = new List<Toboggan>
            {
                new Toboggan(map, new Slope(1, 1)),
                new Toboggan(map, new Slope(3, 1)),
                new Toboggan(map, new Slope(5, 1)),
                new Toboggan(map, new Slope(7, 1)),
                new Toboggan(map, new Slope(1, 2)),
            };

            //When
            var multipliedNumberOfTreesEncountered = toboggans
            .Select(toboggan => toboggan.GetNumberOfTreesEncounteredOnTrajectory())
            .Aggregate(1L, (a, b) => a * b);

            //Then
            Assert.Equal(1718180100L, multipliedNumberOfTreesEncountered);
        }
    }
}