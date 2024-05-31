using DrMW.Cqrs.Core.Commons;
using DrMW.Cqrs.Core.Edu;
using DrMW.Cqrs.Core.Edu.Questionnaires;

namespace DrMW.Cqrs.Core.Students;

public class Student : BaseEntity<Guid>
{
    public override Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }

    public Detail? Detail { get; set; }
    
    public Status? Status { get; set; }
    public int StatusId { get; set; }
    
    public EduLevel? EduLevel { get; set; }
    public int EduLevelId { get; set; }
    
    public EduType? EduType { get; set; }
    public int EduTypeId { get; set; }

    public Guid GroupId { get; set; }
    public Group? Group { get; set; }
    
}