using System;
using System.IO;

namespace AdventOfCode.Day06.Tests
{
    public static class GroupsAnswersDescription
    {
        public static string ProblemDescription
            => string.Join(
                "\n",
                File.ReadAllLines(
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory, "Day06/input.txt")));
    }
}