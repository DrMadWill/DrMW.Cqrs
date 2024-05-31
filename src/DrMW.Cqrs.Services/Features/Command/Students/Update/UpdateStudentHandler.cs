using AutoMapper;
using DrMW.Cqrs.Core.Students;
using DrMW.Cqrs.Repository.Abstractions.Cqrs;
using DrMW.Cqrs.Repository.Abstractions.SystemRepos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DrMW.Cqrs.Service.Features.Command.Students.Update;

public class UpdateStudentHandler : IRequestHandler<UpdateStudentReq,bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IWriteRepository<Student, Guid> _studentRepo;
    public UpdateStudentHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _studentRepo = unitOfWork.Repository<Student, Guid>();
    }
    
    public async Task<bool> Handle(UpdateStudentReq request, CancellationToken cancellationToken)
    {
        var student = await _studentRepo.GetAllQueryable().FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken: cancellationToken);
        _mapper.Map(request, student);
        await _unitOfWork.Repository<Student, Guid>().AddAsync(student);
        await _unitOfWork.CommitAsync();
        return true;
    }
}