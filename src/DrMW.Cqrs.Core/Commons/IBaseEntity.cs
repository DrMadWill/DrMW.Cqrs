namespace DrMW.Cqrs.Core.Commons;

public interface IBaseEntity<T> : IOriginEntity<T>
{
    DateTime CreateAt { get; set; }
    DateTime UpdateAt { get; set; }
    public bool Deleted { get; set; }
}