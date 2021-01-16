﻿using System.Linq;

namespace AdventOfCode.Day04
{
    public static class PassportScanner
    {
        public static int CountValidPassports(string batchFileDescription)
            => PassportParser
            .ParseBatchFile(batchFileDescription)
            .Select(passportDescription => PassportFactory.Create(passportDescription))
            .Where(passport => passport.IsValid())
            .Count();
    }
}