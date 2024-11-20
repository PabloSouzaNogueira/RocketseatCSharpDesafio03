using RocketseatCSharpDesafio03.Domain.Enums;

namespace RocketseatCSharpDesafio03.Domain.Entities;

public class Task
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DateLimit { get; set; }
    public Enums.TaskStatus TaskStatus { get; set; }
    public TaskPriority TaskPriority { get; set; }
}
