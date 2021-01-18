using System;
using System.IO;

namespace AdventOfCode.Day05.Tests
{
    public static class BoardingPassDescription
    {
        public static string ProblemDescription
            => string.Join(
                "\n",
                File.ReadAllLines(
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory, "Day05/input.txt")));
    }
}