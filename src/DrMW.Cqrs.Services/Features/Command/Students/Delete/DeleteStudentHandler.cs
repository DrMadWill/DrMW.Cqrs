using DrMW.Cqrs.Core.Students;
using DrMW.Cqrs.Repository.Abstractions.Cqrs;
using MediatR;

namespace DrMW.Cqrs.Service.Features.Command.Students.Delete;

public class DeleteStudentHandler : IRequestHandler<DeleteStudentReq,bool>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteStudentHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<bool> Handle(DeleteStudentReq request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Repository<Student, Guid>().DeleteWhereAsync(s => s.Id == request.Id);
        await _unitOfWork.CommitAsync();
        return true;
    }
}