using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day04
{
    public class Passport
    {
        private const string CredentialMissingFieldDiscriminator = "cid";

        private IEnumerable<string> requiredFieldsDescritpionsForPassport = new HashSet<string> {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid",
            "cid"
        };

        private IEnumerable<string> requiredFieldsDescriptionsForCredential = new HashSet<string> {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid"
        };


        private IEnumerable<string> fieldsDescriptions;

        public Passport(string passportDescription)
        {
            this.fieldsDescriptions = PassportParser.ParsePassportDescription(passportDescription);
        }


        public bool IsValid()
        {
            var requiredFieldsDescriptions = IsPassport() ?
            requiredFieldsDescritpionsForPassport :
            requiredFieldsDescriptionsForCredential;

            return requiredFieldsDescriptions
              .All(requiredFieldDescription
              => fieldsDescriptions.Any(fieldDescription
                  => fieldDescription.StartsWith(requiredFieldDescription)));
        }

        private bool IsPassport()
        => fieldsDescriptions
        .Any(fieldDescription
            => fieldDescription.StartsWith(CredentialMissingFieldDiscriminator));
    }
}