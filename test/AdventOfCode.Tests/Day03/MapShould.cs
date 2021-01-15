using System.Linq;
using Xunit;

namespace AdventOfCode.Day03.Tests
{
    public class MapShould
    {
        [Theory]
        [InlineData(2, 4, false)]
        [InlineData(3, 7, true)]
        [InlineData(4, 10, false)]
        [InlineData(5, 13, true)]
        [InlineData(6, 16, true)]
        [InlineData(7, 19, false)]
        [InlineData(8, 22, true)]
        [InlineData(9, 25, true)]
        [InlineData(10, 28, true)]
        [InlineData(11, 31, true)]
        public void Give_tree_presence_at(int lineNumber, int position, bool expectedTreePresence)
        {
            //Given
            var map = new Map(MapDescription.ExampleDescription);

            //When
            var treePresence = map.GetTreePresenceAt(lineNumber, position);

            //Then
            Assert.Equal(expectedTreePresence, treePresence);
        }

        [Fact]
        public void Parse_map_description()
        {
            //Given
            var expectedNumberOfLines = 11;

            //When
            var map = new Map(MapDescription.ExampleDescription);

            //Then
            Assert.Equal(expectedNumberOfLines, map.Lines.Count());
        }
    }
}