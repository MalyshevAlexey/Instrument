using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instrument.Specifications
{
    public static class Spec<T>
    {
        public static Specification<T> NotNull<TProperty>(Func<T, TProperty> propertyGetter) =>
            new Property<T, TProperty>(propertyGetter, new NotNull<TProperty>());

        public static Specification<T> Null<TProperty>(Func<T, TProperty> propertyGetter) =>
            NotNull(propertyGetter).Not();

        public static Specification<T> IsTrue(Func<T, bool> predicate) =>
            new Predicate<T>(predicate);

        public static Specification<T> NonEmptyString(Func<T, string> propertyGetter) =>
            new Property<T, string>(propertyGetter, new NonEmptyString());

    }

    public static class Spec
    {
        public static Specification IsTrue(Func<bool> predicate) =>
            new Predicate(predicate);
    }
}
