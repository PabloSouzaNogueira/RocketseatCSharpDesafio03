using RocketseatCSharpDesafio03.Communication.Responses;
using RocketseatCSharpDesafio03.Repository.Repositories;

namespace RocketseatCSharpDesafio03.Application.UseCases.Task.GetAll;

public class GetAllTaskUseCase
{
    readonly TaskRepository _taskRepository;

    public GetAllTaskUseCase()
    {
        _taskRepository = new TaskRepository();
    }

    public ResponseAllTaskJson Execute()
    {
        var tasks = _taskRepository.GetAll();

        return new ResponseAllTaskJson() { Tasks = ResponseTaskJson.ConvertToJson(tasks) };
    }
}