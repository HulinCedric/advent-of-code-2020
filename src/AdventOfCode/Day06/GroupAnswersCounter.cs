using System;
using System.Linq;

namespace AdventOfCode.Day06
{
    public static class GroupsAnswersCounter
    {
        public static int SumDisctintYesAnswers(string groupsAnswersDescription)
            => groupsAnswersDescription
            .Split("\n\n")
            .Select(personAnswers => personAnswers.Replace("\n", ""))
            .Select(groupAnswers => new string(groupAnswers.Distinct().ToArray()))
            .Select(distinctGroupAnswers => distinctGroupAnswers.Count())
            .Aggregate((accumulator, distinctGroupAnswersCount) => accumulator + distinctGroupAnswersCount);


        public static int SumQuestionsToWhichEveryoneAnsweredYes(string groupsAnswersDescription)
            => groupsAnswersDescription
            .Split("\n\n")
            .Select(groupAnswers => 
                (PersonCount: groupAnswers.Where(c => c == '\n').Count() + 1, 
                 Answers: groupAnswers.Replace("\n", "")))
            .Select(groupPersonCountAndAnswers => 
                groupPersonCountAndAnswers.Answers
                .GroupBy(answer => answer)
                .Where(sameAnswers => sameAnswers.Count() == groupPersonCountAndAnswers.PersonCount)
                .Count())
            .Aggregate((accumulator, questionsEveryoneAnsweredYesByGroupCount) => accumulator + questionsEveryoneAnsweredYesByGroupCount);
    }
}