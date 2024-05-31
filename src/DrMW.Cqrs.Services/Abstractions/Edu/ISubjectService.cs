using DrMW.Cqrs.Models.Dtos.Edu;
using DrMW.Cqrs.Models.Requests.Subjects;

namespace DrMW.Cqrs.Service.Abstractions.Edu;

public interface ISubjectService
{
    Task<List<SubjectDto>> GetAll();
    Task<SubjectDto> Get(Guid id);
    Task<bool> AddAsync(AddSubjectReq req);
    Task<bool> UpdateAsync(UpdateSubjectReq req);
    Task<bool> DeleteAsync(Guid id); 
}