using System.Linq;

namespace AdventOfCode.Day04
{
    public class BirthYearPassportField
    {
        private string value;

        public BirthYearPassportField(string value) 
        => this.value = value;

        public bool IsValid()
        =>
        value.All(c => char.IsDigit(c)) &&
        int.Parse(value) >= 1920 &&
        int.Parse(value) <= 2002;
    }
}