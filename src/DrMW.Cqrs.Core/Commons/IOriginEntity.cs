namespace DrMW.Cqrs.Core.Commons;

public interface IOriginEntity<T>
{
    T Id { get; set; }
}