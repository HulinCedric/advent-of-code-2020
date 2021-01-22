﻿namespace AdventOfCode.Day04
{
    public class UnknownPassportField
        : PassportField
    {
        internal UnknownPassportField(string name, string value)
            : base(value)
        { }

        public override bool IsValid()
            => false;
    }
}