using DrMW.Cqrs.Models.Requests.Groups;
using DrMW.Cqrs.Service.Abstractions.Edu;
using Microsoft.AspNetCore.Mvc;

namespace DrMW.Cqrs.Api.Controllers;

public class GroupsController : BaseController
{
    private readonly IGroupService _groupService;
    public GroupsController(IGroupService groupService)
    {
        _groupService = groupService;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _groupService.GetAll());
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _groupService.Get(id));
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(AddGroupReq request)
    {
        return Ok(await _groupService.AddAsync(request));
    } 
    
    [HttpPut]
    public async Task<IActionResult> Put([FromBody]UpdateGroupReq request)
    {
        return Ok(await _groupService.UpdateAsync(request));
    } 
    
    
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        return Ok(await _groupService.DeleteAsync(id));
    }
    
}