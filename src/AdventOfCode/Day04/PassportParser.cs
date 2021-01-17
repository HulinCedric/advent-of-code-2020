using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day04
{
    public static class PassportParser
    {
        private static readonly string BlankLineDescription =
        "\n" +
        "\n";

        public static IEnumerable<string> ParseBatchFile(string batchFileDescription)
        => batchFileDescription
        .Split(BlankLineDescription)
        .Select(passportDescription => passportDescription.Trim());

        public static IEnumerable<string> ParsePassportDescription(string passportDescription)
        => passportDescription
        .Replace("\n", " ")
        .Split(" ")
        .Select(passportFieldDescription => passportFieldDescription);

        public static PassportFieldInformations ParsePassportFieldDescription(
            string passportFieldDescription)
            => new PassportFieldInformations(
                passportFieldDescription.Split(":").First(),
                passportFieldDescription.Split(":").Last());
    }
}