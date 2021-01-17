using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day04
{
    public abstract class AbstractPassport
    {
        private IEnumerable<PassportField> passportFields;

        protected AbstractPassport(string passportDescription)
        => this.passportFields = PassportParser.ParsePassportDescription(passportDescription)
            .Select(passportFieldDescription => PassportFieldFactory.Create(passportFieldDescription));

        public bool ContainsAllRequiredFields()
            => GetRequiredFields()
            .All(requiredFieldType => passportFields
                .Select(passportField => passportField.GetType())
                .Any(passportFieldType => requiredFieldType.IsAssignableFrom(passportFieldType)));

        public bool ContainsAllRequiredValidFields()
            => ContainsAllRequiredFields() &&
            passportFields.All(passportField => passportField.IsValid());

        protected abstract IEnumerable<Type> GetRequiredFields();
    }
}