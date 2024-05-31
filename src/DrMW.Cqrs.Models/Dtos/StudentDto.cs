using DrMW.Cqrs.Core.Students;
using DrMW.Cqrs.Models.Dtos.Common;
using DrMW.Cqrs.Models.Dtos.Edu;

namespace DrMW.Cqrs.Models.Dtos;

public class StudentDto : BaseDto<Guid>
{
    public string Surname { get; set; }
    public string Patronymic { get; set; }

    public StudentDetailDto? Detail { get; set; }
    
    public BaseCategory? Status { get; set; }
    public int StatusId { get; set; }
    
    public BaseCategory? EduLevel { get; set; }
    public int EduLevelId { get; set; }
    
    public BaseCategory? EduType { get; set; }
    public int EduTypeId { get; set; }

    public Guid GroupId { get; set; }
    public GroupDto? Group { get; set; }
}

public class StudentDetailDto
{
    public Guid Id { get; set; }
    public StudentDto? Student { get; set; }
    public string? Address { get; set; }
    public string? Military { get; set; }
}