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
    }
}