using Xunit;

namespace AdventOfCode.Day03.Tests
{
    public class MapLineShould
    {
        private readonly string LineDescription = "#...#...#..";

        private MapLine mapLine;

        public MapLineShould()
            => mapLine = new(LineDescription);

        [Theory]
        [InlineData(01, '#')]
        [InlineData(02, '.')]
        [InlineData(03, '.')]
        [InlineData(04, '.')]
        [InlineData(05, '#')]
        [InlineData(06, '.')]
        [InlineData(07, '.')]
        [InlineData(08, '.')]
        [InlineData(09, '#')]
        [InlineData(10, '.')]
        [InlineData(11, '.')]
        public void Give_element_description_of_the_line_at(int position, char expectedElementDescription)
        {
            //When
            var elementDescription = mapLine.GetElementDescriptionAtPosition(position);

            //Then
            Assert.Equal(expectedElementDescription, elementDescription);
        }

        [Theory]

        // Second times
        [InlineData(12, '#')]
        [InlineData(13, '.')]
        [InlineData(14, '.')]
        [InlineData(15, '.')]
        [InlineData(16, '#')]
        [InlineData(17, '.')]
        [InlineData(18, '.')]
        [InlineData(19, '.')]
        [InlineData(20, '#')]
        [InlineData(21, '.')]
        [InlineData(22, '.')]

        // Third times
        [InlineData(23, '#')]
        [InlineData(24, '.')]
        [InlineData(25, '.')]
        [InlineData(26, '.')]
        [InlineData(27, '#')]
        [InlineData(28, '.')]
        [InlineData(29, '.')]
        [InlineData(30, '.')]
        [InlineData(31, '#')]
        [InlineData(32, '.')]
        [InlineData(33, '.')]
        public void Have_the_same_pattern_repeats_to_the_right_many_times(int position, char expectedElementDescription)
        {
            //When
            var elementDescription = mapLine.GetElementDescriptionAtPosition(position);

            //Then
            Assert.Equal(expectedElementDescription, elementDescription);
        }
    }
}