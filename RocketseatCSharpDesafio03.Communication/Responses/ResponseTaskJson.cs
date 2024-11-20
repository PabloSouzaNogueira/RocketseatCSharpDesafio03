using RocketseatCSharpDesafio03.Domain.Enums;

namespace RocketseatCSharpDesafio03.Communication.Responses;
public class ResponseTaskJson
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DateLimit { get; set; }
    public Domain.Enums.TaskStatus TaskStatus { get; set; }
    public TaskPriority TaskPriority { get; set; }

    public static ResponseTaskJson ConvertToJson(Domain.Entities.Task? task)
    {
        if (task == null)
            return null;

        var responseShortTaskJson = new ResponseTaskJson();
        responseShortTaskJson.Id = task.Id;
        responseShortTaskJson.Name = task.Name;
        responseShortTaskJson.Description = task.Description;
        responseShortTaskJson.DateLimit = task.DateLimit;
        responseShortTaskJson.TaskStatus = task.TaskStatus;
        responseShortTaskJson.TaskPriority = task.TaskPriority;

        return responseShortTaskJson;
    }

    public static List<ResponseTaskJson> ConvertToJson(List<Domain.Entities.Task> tasks)
    {
        var responseShortTaskJsons = new List<ResponseTaskJson>();
        tasks.ForEach(task => { responseShortTaskJsons.Add(ConvertToJson(task)); });
        return responseShortTaskJsons;
    }
}