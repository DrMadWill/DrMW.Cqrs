using DrMW.Cqrs.Core.Commons;
using DrMW.Cqrs.Core.Edu.Questionnaires;
using DrMW.Cqrs.Core.Students;

namespace DrMW.Cqrs.Core.Edu;

public class Group : BaseEntity<Guid>
{
    public string Name { get; set; }
    
    public EduLevel? EduLevel { get; set; }
    public int EduLevelId { get; set; }
    public EduType? EduType { get; set; }
    public int EduTypeId { get; set; }
    public List<Student>? Students { get; set; }
    public List<GroupSubject>? Subjects { get; set; }
}