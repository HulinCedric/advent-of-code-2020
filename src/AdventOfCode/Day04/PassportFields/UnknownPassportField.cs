﻿namespace AdventOfCode.Day04.PassportFields
{
    public class UnknownPassportField
        : PassportField
    {
        internal UnknownPassportField(string value)
            : base(value)
        {
        }

        public override bool IsValid()
            => false;
    }
}