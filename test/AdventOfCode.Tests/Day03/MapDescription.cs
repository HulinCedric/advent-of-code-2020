using System;
using System.IO;

namespace AdventOfCode.Day03.Tests
{
    public static class MapDescription
    {
        public static readonly string ExampleDescription =
            "..##......." + "\n" +
            "#...#...#.." + "\n" +
            ".#....#..#." + "\n" +
            "..#.#...#.#" + "\n" +
            ".#...##..#." + "\n" +
            "..#.##....." + "\n" +
            ".#.#.#....#" + "\n" +
            ".#........#" + "\n" +
            "#.##...#..." + "\n" +
            "#...##....#" + "\n" +
            ".#..#...#.#";

        public static string ProblemDescription
            => string.Join(
                "\n",
                File.ReadAllLines(
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory, "Day03/input.txt")));
    }
}