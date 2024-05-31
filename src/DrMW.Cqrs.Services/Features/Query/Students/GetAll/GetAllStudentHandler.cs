using AutoMapper;
using DrMW.Cqrs.Core.Students;
using DrMW.Cqrs.Models.Dtos;
using DrMW.Cqrs.Repository.Abstractions.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DrMW.Cqrs.Service.Features.Query.Students.GetAll;

public class GetAllStudentHandler : IRequestHandler<GetAllStudentReq,List<StudentDto>>
{
    private readonly ISelectRepositories _selectRepositories;
    private readonly IMapper _mapper;
    public GetAllStudentHandler(ISelectRepositories selectRepositories, IMapper mapper)
    {
        _selectRepositories = selectRepositories;
        _mapper = mapper;
    }
    
    public async Task<List<StudentDto>> Handle(GetAllStudentReq request, CancellationToken cancellationToken)
    {
        IQueryable<Student> studentsQuery = _selectRepositories.Repository<Student, Guid>().GetAllQueryable().Include(s => s.Status);

        #region Filter

        // filter
        if (request?.Id != null) studentsQuery = studentsQuery.Where(s => s.Id == request.Id);
        if (request?.GroupId != null) studentsQuery = studentsQuery.Where(s => s.GroupId == request.GroupId);
        if(!string.IsNullOrEmpty(request?.Name)) studentsQuery = studentsQuery.Where(s => s.Name.ToLower().Contains( request.Name.ToLower().Trim()));
        if(!string.IsNullOrEmpty(request?.Surname)) studentsQuery = studentsQuery.Where(s => s.Surname.ToLower().Contains(request.Surname.ToLower().Trim()));
        if(!string.IsNullOrEmpty(request?.Patronymic)) studentsQuery = studentsQuery.Where(s => s.Patronymic.ToLower().Contains( request.Patronymic.ToLower().Trim()));

        #endregion
        
        var students = await studentsQuery.ToListAsync(cancellationToken: cancellationToken);
        return students.Select(_mapper.Map<StudentDto>).ToList();
    }
}