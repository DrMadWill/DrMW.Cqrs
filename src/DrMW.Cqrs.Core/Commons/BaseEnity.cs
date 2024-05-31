namespace DrMW.Cqrs.Core.Commons;

public class BaseEntity<T> : IBaseEntity<T>
{
    public virtual T Id { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public bool Deleted { get; set; }
}