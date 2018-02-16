using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Instrument.Interfaces;

namespace Instrument.Specifications
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfiedBy(T obj);

        public Specification<T> And(Specification<T> other) =>
            new Composite<T>((results) => results.All(res => res == true), this, other);

        public Specification<T> Or(Specification<T> other) =>
            new Composite<T>((results) => results.Any(res => res == true), this, other);

        public Specification<T> Not() =>
            new Transform<T>(res => !res, this);
    }

    public abstract class Specification : ISpecification
    {
        public abstract bool IsSatisfiedBy();

        public Specification Not() =>
            new Transform(res => !res, this);

        public Specification And(Specification other) =>
            new Composite((results) => results.All(res => res == true), this, other);
    }
}
