using AutoMapper;
using DrMW.Cqrs.Core.Edu;
using DrMW.Cqrs.Models.Dtos.Edu;
using DrMW.Cqrs.Models.Requests.Subjects;
using DrMW.Cqrs.Repository.Abstractions.Cqrs;
using DrMW.Cqrs.Service.Abstractions.Edu;
using Microsoft.EntityFrameworkCore;

namespace DrMW.Cqrs.Service.Concretes.Edu;

public class SubjectService : ISubjectService
{
    private readonly ISelectRepositories _selectRepositories;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public SubjectService(ISelectRepositories selectRepositories,IUnitOfWork unitOfWork, IMapper mapper)
    {
        _selectRepositories = selectRepositories;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<SubjectDto>> GetAll()
    {
        return (await _selectRepositories.Repository<Subject, Guid>().GetAllListAsync())
            .Select(_mapper.Map<SubjectDto>)
            .ToList();
    }

    public async Task<SubjectDto> Get(Guid id)
    {
        var subject = await _selectRepositories.Repository<Subject, Guid>().GetFirstAsync(s => s.Id == id);
        return _mapper.Map<SubjectDto>(subject);
    }

    public async Task<bool> AddAsync(AddSubjectReq req)
    {
        await _unitOfWork.Repository<Subject, Guid>().AddAsync(_mapper.Map<Subject>(req));
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(UpdateSubjectReq req)
    {
        var subject = await _unitOfWork.Repository<Subject, Guid>().GetAllQueryable(true)
            .FirstOrDefaultAsync(s => s.Id == req.Id);
        _mapper.Map(req, subject);
        await _unitOfWork.Repository<Subject, Guid>().UpdateAsync(subject);
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        await _unitOfWork.Repository<Subject, Guid>().DeleteWhereAsync(s => s.Id == id);
        await _unitOfWork.CommitAsync();
        return true; 
    }
}