﻿namespace AdventOfCode.Day04
{
    public abstract class PassportField
    {
        protected readonly string value;

        public PassportField(string value)
            => this.value = value;

        public abstract bool IsValid();
    }
}