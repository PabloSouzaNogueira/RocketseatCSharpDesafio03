using RocketseatCSharpDesafio03.Communication.Responses;
using RocketseatCSharpDesafio03.Domain.Enums;

namespace RocketseatCSharpDesafio03.Communication.Requests;

public class RequestTaskJson
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DateLimit { get; set; }
    public Domain.Enums.TaskStatus TaskStatus { get; set; }
    public TaskPriority TaskPriority { get; set; }


    public static Domain.Entities.Task  ConvertToEntity(RequestTaskJson? requestTaskJson)
    {
        if (requestTaskJson == null)
            return null;

        var task = new Domain.Entities.Task();
        task.Name = requestTaskJson.Name;
        task.Description = requestTaskJson.Description;
        task.DateLimit = requestTaskJson.DateLimit;
        task.TaskStatus = requestTaskJson.TaskStatus;
        task.TaskPriority = requestTaskJson.TaskPriority;

        return task;
    }
}
