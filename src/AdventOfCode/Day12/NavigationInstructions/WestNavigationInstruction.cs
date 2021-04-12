﻿using AdventOfCode.Day12.Ships;

namespace AdventOfCode.Day12.NavigationInstructions
{
    public record WestNavigationInstruction
        : NavigationInstruction
    {
        public WestNavigationInstruction(char action, int value)
            : base(action, value)
        {
        }

        public override void Execute(Ship ship)
            => ship.MoveWest(Value);
    }
}