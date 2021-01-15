using System;
using System.IO;

namespace AdventOfCode.Day03.Tests
{
    public static class MapDescription
    {
        public static readonly string ExampleDescription =
            "..##......." + Environment.NewLine +
            "#...#...#.." + Environment.NewLine +
            ".#....#..#." + Environment.NewLine +
            "..#.#...#.#" + Environment.NewLine +
            ".#...##..#." + Environment.NewLine +
            "..#.##....." + Environment.NewLine +
            ".#.#.#....#" + Environment.NewLine +
            ".#........#" + Environment.NewLine +
            "#.##...#..." + Environment.NewLine +
            "#...##....#" + Environment.NewLine +
            ".#..#...#.#";

        public static string ProblemDescription
            => string.Join(
                Environment.NewLine,
                File.ReadAllLines(
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory, "Day03/input.txt")));
    }
}