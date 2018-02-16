using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrument.Specifications
{
    internal class NonEmptyString : Specification<string>
    {
        public override bool IsSatisfiedBy(string obj) =>
            !string.IsNullOrEmpty(obj);
    }
}
