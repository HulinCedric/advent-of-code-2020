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
    }
}