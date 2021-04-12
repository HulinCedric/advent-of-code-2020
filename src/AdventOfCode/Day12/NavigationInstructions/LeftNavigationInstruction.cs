﻿using AdventOfCode.Day12.Ships;

namespace AdventOfCode.Day12.NavigationInstructions
{
    public record LeftNavigationInstruction
        : NavigationInstruction
    {
        public LeftNavigationInstruction(char action, int value)
            : base(action, value)
        {
        }

        public override void Execute(Ship ship)
            => ship.TurnLeft(Value);
    }
}