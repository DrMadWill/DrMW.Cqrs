using DrMW.Cqrs.Service.Features.Command.Students.Add;
using DrMW.Cqrs.Service.Features.Command.Students.Delete;
using DrMW.Cqrs.Service.Features.Command.Students.Update;
using DrMW.Cqrs.Service.Features.Query.Students.GetAll;
using DrMW.Cqrs.Service.Features.Students.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DrMW.Cqrs.Api.Controllers;

public class StudentsController : BaseController
{
    private readonly IMediator _mediator;
    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery]GetAllStudentReq request)
    {
        var studnet = await _mediator.Send(request);
        return Ok(studnet);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var request = new GetStudentRequest() { Id = id};
        var studnet = await _mediator.Send(request);
        return Ok(studnet);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(AddStudentReq request)
    {
        var studnet = await _mediator.Send(request);
        return Ok(studnet);
    } 
    
    [HttpPut]
    public async Task<IActionResult> Put([FromBody]UpdateStudentReq request)
    {
        var studnet = await _mediator.Send(request);
        return Ok(studnet);
    } 
    
    
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var request = new DeleteStudentReq() { Id = id};
        var studnet = await _mediator.Send(request);
        return Ok(studnet);
    }  
    
}