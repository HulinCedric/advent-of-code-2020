using System;
using System.IO;

namespace AdventOfCode.Day04.Tests
{
    public static class BatchFileDescription
    {
        public static readonly string ExampleDescription =
        PassportDescription.First +
        Environment.NewLine +
        Environment.NewLine +
        PassportDescription.Second +
        Environment.NewLine +
        Environment.NewLine +
        PassportDescription.Third +
        Environment.NewLine +
        Environment.NewLine +
        PassportDescription.Fourth;

        public static string ProblemDescription
            => string.Join(
                Environment.NewLine,
                File.ReadAllLines(
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory, "Day04/input.txt")));
    }
}