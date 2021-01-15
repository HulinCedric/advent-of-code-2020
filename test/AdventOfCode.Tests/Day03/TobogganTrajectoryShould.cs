using System;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode.Day03.Tests
{
    public class TobogganTrajectoryShould
    {

        [Fact]
        public void Encounter_7_trees_for_example()
        {
            //Given
            var expectedEncounteredTreesCount = 7;

            //When
            var encounteredTreesCount = 0;

            //Then
            Assert.Equal(expectedEncounteredTreesCount, encounteredTreesCount);
        }
    }
}