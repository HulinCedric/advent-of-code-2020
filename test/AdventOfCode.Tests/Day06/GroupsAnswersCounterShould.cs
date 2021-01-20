using Xunit;

namespace AdventOfCode.Day06.Tests
{

    public class GroupsAnswersCounterShould
    {
        [Theory]
        [InlineData("a", 1)]
        [InlineData("a\na", 1)]
        [InlineData("a\n\na", 2)]
        [InlineData("a\n\na\na", 2)]
        [InlineData("a\n\na\nb", 3)]
        [InlineData("abc\n\na\nb\nc\n\nab\nac\n\na\na\na\na\n\nb", 11)]
        public void Sum_distinct_yes_answers_count_of_each_groups(
            string groupAnswersDescription,
            int expectedYesAnswersSum)
        {
            //When
            var yesAnswersSum = GroupsAnswersCounter.SumDisctintYesAnswers(groupAnswersDescription);

            //Then
            Assert.Equal(expectedYesAnswersSum, yesAnswersSum);
        }

        [Fact]
        public void Sum_distinct_yes_answers_count_of_each_groups_for_problem()
        {
            //Given
            var groupAnswersDescription = GroupsAnswersDescription.ProblemDescription;
            var expectedYesAnswersCount = 7283;

            //When
            var yesAnswersSum = GroupsAnswersCounter.SumDisctintYesAnswers(groupAnswersDescription);

            //Then
            Assert.Equal(expectedYesAnswersCount, yesAnswersSum);
        }
    }
}