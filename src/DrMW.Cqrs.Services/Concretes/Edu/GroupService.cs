using AutoMapper;
using DrMW.Cqrs.Core.Edu;
using DrMW.Cqrs.Models.Dtos.Edu;
using DrMW.Cqrs.Models.Requests.Groups;
using DrMW.Cqrs.Repository.Abstractions.Cqrs;
using DrMW.Cqrs.Repository.Abstractions.SystemRepos;
using DrMW.Cqrs.Service.Abstractions.Edu;
using Microsoft.EntityFrameworkCore;

namespace DrMW.Cqrs.Service.Concretes.Edu;

public class GroupService : IGroupService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IReadRepository<Group, Guid> _readRepository;
    private readonly IWriteRepository<Group, Guid> _writeRepository;
    public GroupService(ISelectRepositories selectRepositories,IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _readRepository = selectRepositories.Repository<Group, Guid>();
        _writeRepository = _unitOfWork.Repository<Group, Guid>();
    }
    
    public async Task<List<GroupDto>> GetAll()
    {
        return (await _readRepository.GetAllListAsync())
            .Select(_mapper.Map<GroupDto>)
            .ToList(); 
    }

    public async Task<GroupDto> Get(Guid id)
    {
        var group = await _readRepository.GetFirstAsync(s => s.Id == id);
        return _mapper.Map<GroupDto>(group); 
    }

    public async Task<bool> AddAsync(AddGroupReq req)
    {
        await _writeRepository.AddAsync(_mapper.Map<Group>(req));
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(UpdateGroupReq req)
    {
        var group = await _writeRepository.GetAllQueryable(true)
            .FirstOrDefaultAsync(s => s.Id == req.Id); 
        _mapper.Map(req, group);
        await _writeRepository.UpdateAsync(group);
        await _unitOfWork.CommitAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        await _writeRepository.DeleteWhereAsync(s => s.Id == id);
        await _unitOfWork.CommitAsync();
        return true; 
    }
}