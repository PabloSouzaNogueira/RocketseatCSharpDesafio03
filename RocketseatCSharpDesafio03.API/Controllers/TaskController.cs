using Microsoft.AspNetCore.Mvc;
using RocketseatCSharpDesafio03.Application.UseCases.Task.Delete;
using RocketseatCSharpDesafio03.Application.UseCases.Task.GetAll;
using RocketseatCSharpDesafio03.Application.UseCases.Task.GetById;
using RocketseatCSharpDesafio03.Application.UseCases.Task.Register;
using RocketseatCSharpDesafio03.Application.UseCases.Task.Update;
using RocketseatCSharpDesafio03.Communication.Requests;
using RocketseatCSharpDesafio03.Communication.Responses;

namespace RocketseatCSharpDesafio03.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    readonly GetAllTaskUseCase _getAllTaskUseCase;
    readonly GetTaskByIdUseCase _getTaskByIdUseCase;
    readonly RegisterTaskUseCase _registerTaskUseCase;
    readonly UpdateTaskUseCase _updateTaskUseCase;
    readonly DeleteTaskByIdUseCase _deleteTaskByIdUseCase;

    public TaskController()
    {
        _getAllTaskUseCase = new GetAllTaskUseCase();
        _getTaskByIdUseCase = new GetTaskByIdUseCase();
        _deleteTaskByIdUseCase = new DeleteTaskByIdUseCase();
        _updateTaskUseCase = new UpdateTaskUseCase();
        _registerTaskUseCase = new RegisterTaskUseCase();
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var response = _getAllTaskUseCase.Execute();

        if (response.Tasks.Any())
            return Ok(response);

        return NoContent();
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Get([FromRoute] int id)
    {
        var response = _getTaskByIdUseCase.Execute(id);

        if (response == null)
            return NotFound();

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestTaskJson request)
    {
        var taskId = _registerTaskUseCase.Execute(request);

        if(taskId.HasValue)
            return Created(string.Empty, taskId);

        return BadRequest();
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update([FromRoute] int id, [FromBody] RequestTaskJson request)
    {
        var taskId = _updateTaskUseCase.Execute(id, request);

        if (taskId.HasValue)
            return NoContent();

        return BadRequest();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] int id)
    {
        var taskId = _deleteTaskByIdUseCase.Execute(id);

        if (taskId.HasValue)
            return NoContent();

        return NotFound();
    }
}