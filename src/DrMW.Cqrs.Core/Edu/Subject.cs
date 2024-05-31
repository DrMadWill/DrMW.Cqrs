using DrMW.Cqrs.Core.Commons;
using DrMW.Cqrs.Core.Edu.Questionnaires;

namespace DrMW.Cqrs.Core.Edu;

public class Subject : BaseEntity<Guid>
{
    public string Name { get; set; }
    
    public EduLevel? Level { get; set; }
    public int LevelId { get; set; }
}