using RocketseatCSharpDesafio03.Communication.Requests;
using RocketseatCSharpDesafio03.Repository.Repositories;

namespace RocketseatCSharpDesafio03.Application.UseCases.Task.Update;

public class UpdateTaskUseCase
{
    readonly TaskRepository _taskRepository;

    public UpdateTaskUseCase()
    {
        _taskRepository = new TaskRepository();
    }

    public int? Execute(int id, RequestTaskJson request)
    {
        var task = RequestTaskJson.ConvertToEntity(request);
        return _taskRepository.Update(id, task);
    }
}