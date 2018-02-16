using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrument.Specifications
{
    internal class Property<TType, TProperty> : Specification<TType>
    {

        private Func<TType, TProperty> PropertyGetter { get; }
        private Specification<TProperty> Subspecification { get; }

        public Property(Func<TType, TProperty> propertyGetter,
                                     Specification<TProperty> subspecification)
        {
            PropertyGetter = propertyGetter;
            Subspecification = subspecification;
        }

        public override bool IsSatisfiedBy(TType obj) =>
            Subspecification.IsSatisfiedBy(
                PropertyGetter(obj));

    }
}
