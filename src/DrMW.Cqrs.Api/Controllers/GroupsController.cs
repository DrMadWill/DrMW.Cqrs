using DrMW.Cqrs.Models.Requests.Groups;
using DrMW.Cqrs.Service.Abstractions.Edu;
using Microsoft.AspNetCore.Mvc;

namespace DrMW.Cqrs.Api.Controllers;

public class GroupsController : BaseController
{
    private readonly IGroupService _subjectService;
    public GroupsController(IGroupService subjectService)
    {
        _subjectService = subjectService;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _subjectService.GetAll());
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _subjectService.Get(id));
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(AddGroupReq request)
    {
        return Ok(await _subjectService.AddAsync(request));
    } 
    
    [HttpPut]
    public async Task<IActionResult> Put([FromBody]UpdateGroupReq request)
    {
        return Ok(await _subjectService.UpdateAsync(request));
    } 
    
    
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _subjectService.DeleteAsync(id));
    }
    
}