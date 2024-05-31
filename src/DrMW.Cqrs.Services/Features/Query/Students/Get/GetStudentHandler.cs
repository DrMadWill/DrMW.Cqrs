using AutoMapper;
using DrMW.Cqrs.Core.Students;
using DrMW.Cqrs.Models.Dtos;
using DrMW.Cqrs.Repository.Abstractions.Cqrs;
using DrMW.Cqrs.Service.Features.Students.Get;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DrMW.Cqrs.Service.Features.Query.Students.Get;

public class GetStudentHandler : IRequestHandler<GetStudentRequest,StudentDto>
{
    private readonly ISelectRepositories _selectRepositories;
    private readonly IMapper _mapper;
    public GetStudentHandler(ISelectRepositories selectRepositories, IMapper mapper)
    {
        _selectRepositories = selectRepositories;
        _mapper = mapper;
    }
    
    public async Task<StudentDto> Handle(GetStudentRequest request, CancellationToken cancellationToken)
    {
        var student = await _selectRepositories.Repository<Student, Guid>().GetAllQueryable()
            .Include(s=> s.Group)
            .Include(s => s.EduType)
            .Include(s=> s.EduLevel)
            .Include(s=> s.Status)
            .Include(s =>s.Detail)
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken: cancellationToken);
        var mapD = _mapper.Map<StudentDto>(student);
        return await Task.FromResult(mapD);
    }
}