﻿using AdventOfCode.Day12.Ships;

namespace AdventOfCode.Day12.NavigationInstructions
{
    public record NorthNavigationInstruction
        : NavigationInstruction
    {
        public NorthNavigationInstruction(char action, int value)
            : base(action, value)
        {
        }

        public override void Execute(Ship ship)
            => ship.MoveNorth(Value);
    }
}