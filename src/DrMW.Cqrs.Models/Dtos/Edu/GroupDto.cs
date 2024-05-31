using DrMW.Cqrs.Models.Dtos.Common;

namespace DrMW.Cqrs.Models.Dtos.Edu;

public class GroupDto : BaseDto<Guid>
{
    public BaseCategory? EduLevel { get; set; }
    public int EduLevelId { get; set; }
    public BaseCategory? EduType { get; set; }
    public int EduTypeId { get; set; }
    public List<StudentDto>? Students { get; set; }
    public List<SubjectDto>? Subjects { get; set; } 
}