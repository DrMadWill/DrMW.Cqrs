using MediatR;

namespace DrMW.Cqrs.Service.Features.Command.Students.Update;

public class UpdateStudentReq : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Patronymic { get; set; }
    public int StatusId { get; set; }
    public int EduLevelId { get; set; }
    public int EduTypeId { get; set; }
    public int GroupId { get; set; }
    public string? Address { get; set; }
    public string? Military { get; set; } 
}