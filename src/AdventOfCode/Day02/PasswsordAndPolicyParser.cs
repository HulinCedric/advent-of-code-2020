﻿using System.Collections.Generic;

namespace AdventOfCode.Day02
{
    public static class PasswsordAndPolicyParser
    {
        public static IEnumerable<string> ParsePasswsordsAndPoliciesDescriptions(string passwsordsAndPoliciesDescriptions)
        {
            return passwsordsAndPoliciesDescriptions.Split("\n");
        }
    }
}