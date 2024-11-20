using RocketseatCSharpDesafio03.Communication.Responses;
using RocketseatCSharpDesafio03.Repository.Repositories;

namespace RocketseatCSharpDesafio03.Application.UseCases.Task.GetById;

public class GetTaskByIdUseCase
{
    readonly TaskRepository _taskRepository;

    public GetTaskByIdUseCase()
    {
        _taskRepository = new TaskRepository();
    }

    public ResponseTaskJson Execute(int id)
    {
        var task = _taskRepository.GetById(id);

        return ResponseTaskJson.ConvertToJson(task);
    }
}
