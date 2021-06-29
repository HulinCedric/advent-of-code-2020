using System;
using System.Collections.Generic;
using AdventOfCode.Day04.PassportFields;

namespace AdventOfCode.Day04.Passports
{
    public class Passport : AbstractPassport
    {
        internal Passport(string passportDescription)
        : base(passportDescription)
        {
        }

        protected override IEnumerable<Type> GetRequiredFields()
            => new HashSet<Type>
            {
                typeof(BirthYearPassportField),
                typeof(IssueYearPassportField),
                typeof(ExpirationYearPassportField),
                typeof(HeightPassportField),
                typeof(HairColorPassportField),
                typeof(EyeColorPassportField),
                typeof(PassportIdPassportField),
                typeof(CountryIdPassportField)
            };
    }
}