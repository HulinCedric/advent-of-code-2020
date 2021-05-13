using System.Linq;

namespace AdventOfCode.Day04.PassportFields
{
    public class HeightInCentimetrePassportField
        : HeightPassportField
    {
        private const int AtLeast = 150;
        private const int AtMost = 193;

        internal HeightInCentimetrePassportField(string value)
            : base(value)
        { }

        public override bool IsValid()
        {
            if (value.EndsWith("cm"))
            {
                var numberPart = value[..^2];
                return numberPart.All(char.IsDigit) &&
                    int.Parse(numberPart) >= AtLeast &&
                    int.Parse(numberPart) <= AtMost;
            }

            return false;
        }
    }
}