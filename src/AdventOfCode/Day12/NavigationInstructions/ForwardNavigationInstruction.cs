﻿using AdventOfCode.Day12.Ships;

namespace AdventOfCode.Day12.NavigationInstructions
{
    public record ForwardNavigationInstruction
        : NavigationInstruction
    {
        public ForwardNavigationInstruction(char action, int value)
            : base(action, value)
        {
        }

        public override void Execute(Ship ship)
            => ship.MoveForward(Value);
    }
}