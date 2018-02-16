using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrument.Specifications
{
    internal class Predicate<T> : Specification<T>
    {
        private Func<T, bool> Delegate { get; }

        public Predicate(Func<T, bool> predicate)
        {
            Delegate = predicate;
        }

        public override bool IsSatisfiedBy(T obj) =>
            Delegate(obj);

    }

    internal class Predicate : Specification
    {
        private Func<bool> Delegate { get; }

        public Predicate(Func<bool> predicate)
        {
            Delegate = predicate;
        }

        public override bool IsSatisfiedBy() =>
            Delegate();
    }
}
