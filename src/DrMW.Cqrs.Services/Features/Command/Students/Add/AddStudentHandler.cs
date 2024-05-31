using AutoMapper;
using DrMW.Cqrs.Core.Students;
using DrMW.Cqrs.Repository.Abstractions.Cqrs;
using MediatR;

namespace DrMW.Cqrs.Service.Features.Command.Students.Add;

public class AddStudentHandler : IRequestHandler<AddStudentReq,bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public AddStudentHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<bool> Handle(AddStudentReq request, CancellationToken cancellationToken)
    {
        var student = _mapper.Map<Student>(request);
        await _unitOfWork.Repository<Student, Guid>().AddAsync(student);
        await _unitOfWork.CommitAsync();
        return true;
    }
}