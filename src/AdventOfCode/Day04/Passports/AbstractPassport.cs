using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Day04.PassportFields;

namespace AdventOfCode.Day04.Passports
{
    public abstract class AbstractPassport
    {
        private IEnumerable<PassportField> passportFields;

        protected AbstractPassport(string passportDescription)
        => passportFields = PassportParser.ParsePassportDescription(passportDescription)
            .Select(PassportFieldFactory.Create);

        public bool ContainsAllRequiredFields()
            => GetRequiredFields()
            .All(requiredFieldType => passportFields
                .Select(passportField => passportField.GetType())
                .Any(requiredFieldType.IsAssignableFrom));

        public bool ContainsAllRequiredValidFields()
            => ContainsAllRequiredFields() &&
            passportFields.All(passportField => passportField.IsValid());

        protected abstract IEnumerable<Type> GetRequiredFields();
    }
}