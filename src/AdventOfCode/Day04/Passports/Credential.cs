using System;
using System.Collections.Generic;

namespace AdventOfCode.Day04
{
    public class Credential : AbstractPassport
    {
        internal Credential(string passportDescription)
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
            };
    }
}