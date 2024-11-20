using RocketseatCSharpDesafio03.Communication.Requests;
using RocketseatCSharpDesafio03.Repository.Repositories;

namespace RocketseatCSharpDesafio03.Application.UseCases.Task.Register;

public class RegisterTaskUseCase
{
    readonly TaskRepository _taskRepository;

    public RegisterTaskUseCase()
    {
        _taskRepository = new TaskRepository();
    }

    public int? Execute(RequestTaskJson request)
    {
        var task = RequestTaskJson.ConvertToEntity(request);
        return _taskRepository.Register(task);
    }
}