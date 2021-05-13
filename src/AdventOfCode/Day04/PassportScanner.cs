using System.Linq;
using AdventOfCode.Day04.Passports;

namespace AdventOfCode.Day04
{
    public static class PassportScanner
    {
        public static int CountValidPassports(string batchFileDescription)
            => PassportParser
            .ParseBatchFile(batchFileDescription)
            .Select(PassportFactory.Create)
            .Where(passport => passport.ContainsAllRequiredFields())
            .Count();

        public static int CountValidPassportsWithValidValues(string batchFileDescription)
           => PassportParser
           .ParseBatchFile(batchFileDescription)
           .Select(PassportFactory.Create)
           .Where(passport => passport.ContainsAllRequiredValidFields())
           .Count();
    }
}