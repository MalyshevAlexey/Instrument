using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrument.Specifications
{
    internal class NotNull<T> : Specification<T>
    {
        public override bool IsSatisfiedBy(T obj) =>
            !object.ReferenceEquals(obj, null);
    }
}
