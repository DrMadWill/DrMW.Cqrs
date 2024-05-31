using DrMW.Cqrs.Models.Dtos;
using MediatR;

namespace DrMW.Cqrs.Service.Features.Students.Get;

public class GetStudentRequest : IRequest<StudentDto>
{
    public Guid Id { get; set; } 
}