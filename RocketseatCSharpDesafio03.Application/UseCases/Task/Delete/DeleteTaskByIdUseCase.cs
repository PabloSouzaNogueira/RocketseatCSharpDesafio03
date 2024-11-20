using RocketseatCSharpDesafio03.Communication.Responses;
using RocketseatCSharpDesafio03.Repository.Repositories;

namespace RocketseatCSharpDesafio03.Application.UseCases.Task.Delete;
public class DeleteTaskByIdUseCase
{
    readonly TaskRepository _taskRepository;

    public DeleteTaskByIdUseCase()
    {
        _taskRepository = new TaskRepository();
    }

    public int? Execute(int id)
    {
        return _taskRepository.DeleteById(id);
    }
}