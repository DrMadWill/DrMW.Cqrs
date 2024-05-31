namespace DrMW.Cqrs.Models.Dtos.Common;

public class BaseDto<T>
{
    public T Id { get; set; }
    public string? Name { get; set; }
}