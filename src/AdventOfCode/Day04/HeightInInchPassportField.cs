using System.Linq;

namespace AdventOfCode.Day04
{
    public class HeightInInchPassportField
        : PassportField
    {
        private const int AtLeast = 59;
        private const int AtMost = 76;

        public HeightInInchPassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
        {
            if (value.EndsWith("in"))
            {
                var numberPart = value[..^2];
                return numberPart.All(c => char.IsDigit(c)) &&
                    int.Parse(numberPart) >= AtLeast &&
                    int.Parse(numberPart) <= AtMost;
            }

            return false;
        }
    }
}