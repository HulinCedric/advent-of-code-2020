using System.Linq;

namespace AdventOfCode.Day04
{
    public static class PassportFactory
    {
        private const string CredentialMissingFieldDiscriminator = "cid";

        public static AbstractPassport Create(string description)
        => IsPassport(description) ?
        new Passport(description) :
        new Credential(description);

        private static bool IsPassport(string fieldsDescriptions)
        => PassportParser
        .ParsePassportDescription(fieldsDescriptions)
        .Any(fieldDescription
            => fieldDescription.StartsWith(CredentialMissingFieldDiscriminator));
    }
}