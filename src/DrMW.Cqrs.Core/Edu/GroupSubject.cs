using DrMW.Cqrs.Core.Commons;

namespace DrMW.Cqrs.Core.Edu;

public class GroupSubject : BaseEntity<Guid>
{
    public Group? Group { get; set; }
    public Guid GroupId { get; set; }
    
    public Subject? Subject { get; set; }
    public Guid SubjectId { get; set; }
}