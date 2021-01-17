using System;
using System.Linq;

namespace AdventOfCode.Day05
{
    public static class SeatIdDecoder
    {
        public static int Decode(string seatDescription)
            => Convert.ToInt32(MapToBinary(seatDescription), 2);

        private static string MapToBinary(string seatDescription)
            => new string(
                seatDescription
                .Select(seatCharacterDescription => MapToBit(seatCharacterDescription))
                .ToArray());

        private static char MapToBit(char seatDescriptionCharacter)
            => seatDescriptionCharacter switch
            {
                'F' => '0',
                'L' => '0',
                _ => '1'
            };
    }
}