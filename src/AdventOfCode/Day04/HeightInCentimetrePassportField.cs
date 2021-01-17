using System.Linq;

namespace AdventOfCode.Day04
{
    public class HeightInCentimetrePassportField
        : PassportField
    {
        private const int AtLeast = 150;
        private const int AtMost = 193;

        public HeightInCentimetrePassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
        {
            if (value.EndsWith("cm"))
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