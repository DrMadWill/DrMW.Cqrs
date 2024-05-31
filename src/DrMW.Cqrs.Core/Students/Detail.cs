using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DrMW.Cqrs.Core.Commons;

namespace DrMW.Cqrs.Core.Students;

public class Detail : IOriginEntity<Guid>
{
    [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
    public Student? Student { get; set; }
    public string? Address { get; set; }
    public string? Military { get; set; }
}