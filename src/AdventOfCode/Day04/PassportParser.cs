using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Day04.PassportFields;

namespace AdventOfCode.Day04
{
    public static class PassportParser
    {
        private static readonly string BlankLineDescription = "\n\n";

        public static IEnumerable<string> ParseBatchFile(string batchFileDescription)
        => batchFileDescription
        .Split(BlankLineDescription)
        .Select(passportDescription => passportDescription.Trim());

        public static IEnumerable<string> ParsePassportDescription(string passportDescription)
        => passportDescription
        .Split(new[] { " ", "\n" }, StringSplitOptions.RemoveEmptyEntries)
        .Select(passportFieldDescription => passportFieldDescription);

        public static PassportFieldInformations ParsePassportFieldDescription(
            string passportFieldDescription)
            => new(
                passportFieldDescription.Split(":").First(),
                passportFieldDescription.Split(":").Last());
    }
}