using DrMW.Cqrs.Models.Dtos.Edu;
using DrMW.Cqrs.Models.Requests.Groups;

namespace DrMW.Cqrs.Service.Abstractions.Edu;

public interface IGroupService
{
    Task<List<GroupDto>> GetAll();
    Task<GroupDto> Get(Guid id);
    Task<bool> AddAsync(AddGroupReq req);
    Task<bool> UpdateAsync(UpdateGroupReq req);
    Task<bool> DeleteAsync(Guid id);
}