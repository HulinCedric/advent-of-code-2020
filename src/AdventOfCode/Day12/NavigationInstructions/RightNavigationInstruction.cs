﻿using AdventOfCode.Day12.Ships;

namespace AdventOfCode.Day12.NavigationInstructions
{
    public record RightNavigationInstruction
        : NavigationInstruction
    {
        public RightNavigationInstruction(char action, int value)
            : base(action, value)
        {
        }

        public override void Execute(Ship ship)
            => ship.TurnRight(Value);
    }
}