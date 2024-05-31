using MediatR;

namespace DrMW.Cqrs.Service.Features.Command.Students.Delete;

public class DeleteStudentReq : IRequest<bool>
{
    public Guid Id { get; set; }
}