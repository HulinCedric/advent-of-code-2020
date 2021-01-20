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
        public void Sum_questions_to_which_anyone_answered_yes(
            string groupAnswersDescription,
            int expectedYesAnswersSum)
        {
            //When
            var yesAnswersSum = GroupsAnswersCounter.SumDisctintYesAnswers(groupAnswersDescription);

            //Then
            Assert.Equal(expectedYesAnswersSum, yesAnswersSum);
        }

        [Theory]
        [InlineData("a", 1)]
        [InlineData("ab", 2)]
        [InlineData("a\na", 1)]
        [InlineData("ab\na", 1)]
        [InlineData("a\n\na", 2)]
        [InlineData("a\n\na\na", 2)]
        [InlineData("a\n\na\nb", 1)]
        [InlineData("abc\n\na\nb\nc\n\nab\nac\n\na\na\na\na\n\nb", 6)]
        public void Sum_questions_to_which_everyone_answered_yes(
            string groupAnswersDescription,
            int expectedAnswersCount)
        {
            //When
            var answersCount = GroupsAnswersCounter.SumQuestionsToWhichEveryoneAnsweredYes(groupAnswersDescription);

            //Then
            Assert.Equal(expectedAnswersCount, answersCount);
        }

        [Fact]
        public void Sum_questions_to_which_anyone_answered_yes_for_problem()
        {
            //Given
            var groupsAnswersDescription = GroupsAnswersDescription.ProblemDescription;
            var expectedYesAnswersCount = 7283;

            //When
            var yesAnswersSum = GroupsAnswersCounter.SumDisctintYesAnswers(groupsAnswersDescription);

            //Then
            Assert.Equal(expectedYesAnswersCount, yesAnswersSum);
        }

        [Fact]
        public void Sum_questions_to_which_everyone_answered_yes_for_problem()
        {
            //Given
            var groupsAnswersDescription = GroupsAnswersDescription.ProblemDescription;
            var expectedAnswersCount = 3520;

            //When
            var answersCount = GroupsAnswersCounter.SumQuestionsToWhichEveryoneAnsweredYes(groupsAnswersDescription);

            //Then
            Assert.Equal(expectedAnswersCount, answersCount);
        }
    }
}