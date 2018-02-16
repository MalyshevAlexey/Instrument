using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrument.Specifications
{
    internal class Composite<T> : Specification<T>
    {
        private Func<IEnumerable<bool>, bool> CompositionFunction { get; }
        private IEnumerable<Specification<T>> Subspecifications { get; }

        public Composite(Func<IEnumerable<bool>, bool> compositionFunction,
                                      params Specification<T>[] subspecifications)
        {
            CompositionFunction = compositionFunction;
            Subspecifications = subspecifications;
        }

        public override bool IsSatisfiedBy(T obj) =>
            CompositionFunction(
                Subspecifications.Select(spec => spec.IsSatisfiedBy(obj)));

    }

    internal class Composite : Specification
    {
        private Func<IEnumerable<bool>, bool> CompositionFunction { get; }
        private IEnumerable<Specification> Subspecifications { get; }

        public Composite(Func<IEnumerable<bool>, bool> compositionFunction,
                                      params Specification[] subspecifications)
        {
            CompositionFunction = compositionFunction;
            Subspecifications = subspecifications;
        }

        public override bool IsSatisfiedBy() =>
            CompositionFunction(
                Subspecifications.Select(spec => spec.IsSatisfiedBy()));

    }
}
