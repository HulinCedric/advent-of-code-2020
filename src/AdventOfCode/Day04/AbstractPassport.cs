using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day04
{
    public abstract class AbstractPassport
    {
        private IEnumerable<string> fieldsDescriptions;

        protected abstract IEnumerable<string> GetRequiredFieldsDescritpions();

        protected AbstractPassport(string passportDescription) 
        => this.fieldsDescriptions = PassportParser.ParsePassportDescription(passportDescription);

        public bool IsValid()
        => GetRequiredFieldsDescritpions()
              .All(requiredFieldDescription
              => fieldsDescriptions.Any(fieldDescription
                  => fieldDescription.StartsWith(requiredFieldDescription)));
    }
}