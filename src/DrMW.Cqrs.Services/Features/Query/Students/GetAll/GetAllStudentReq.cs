using DrMW.Cqrs.Models.Dtos;
using MediatR;

namespace DrMW.Cqrs.Service.Features.Query.Students.GetAll;

public class GetAllStudentReq : IRequest<List<StudentDto>>
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }
    public Guid? GroupId { get; set; }
}