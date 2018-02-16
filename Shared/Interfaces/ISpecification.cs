namespace Instrument.Interfaces
{
    public interface ISpecification
    {
        bool IsSatisfiedBy();
    }

    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T obj);
    }
}
