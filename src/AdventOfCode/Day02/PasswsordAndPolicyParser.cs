using System.Collections.Generic;

namespace AdventOfCode.Day02
{
    public static class PasswsordAndPolicyParser
    {
        public static IEnumerable<string> ParsePasswordsAndPoliciesDescriptions(
            string passwordsAndPoliciesDescriptions)
            => passwordsAndPoliciesDescriptions.Split("\n");
    }
}