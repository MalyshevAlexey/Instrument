using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrument.Specifications
{
    internal class Transform<T> : Specification<T>
    {

        private Func<bool, bool> Transformation { get; }
        private Specification<T> Subspecification { get; }

        public Transform(Func<bool, bool> transformation,
                                      Specification<T> specification)
        {
            Transformation = transformation;
            Subspecification = specification;
        }

        public override bool IsSatisfiedBy(T obj) =>
            Transformation(
                Subspecification.IsSatisfiedBy(obj));

    }

    internal class Transform : Specification
    {

        private Func<bool, bool> Transformation { get; }
        private Specification Subspecification { get; }

        public Transform(Func<bool, bool> transformation,
                                      Specification specification)
        {
            Transformation = transformation;
            Subspecification = specification;
        }

        public override bool IsSatisfiedBy() =>
            Transformation(
                Subspecification.IsSatisfiedBy());

    }
}
