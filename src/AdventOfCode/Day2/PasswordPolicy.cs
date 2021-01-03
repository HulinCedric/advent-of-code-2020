using System.Linq;

namespace AdventOfCode.Day2.Tests
{
    public class PasswordPolicy
    {
        private readonly int atLeast;
        private readonly int atMost;
        private readonly char character;

        public PasswordPolicy(
            int atLeast,
            int atMost,
            char character)
        {
            this.atLeast = atLeast;
            this.atMost = atMost;
            this.character = character;
        }

        public bool Validate(string password)
        {
            var characterCount = ComputeCharacterCount(password);
            return atLeast <= characterCount && characterCount <= atMost;
        }

        private int ComputeCharacterCount(string password)
            => password
            .GroupBy(character => character)
            .Where(groupedCharacters => groupedCharacters.Key == character)
            .Select(c => c.Count())
            .SingleOrDefault();
    }
}