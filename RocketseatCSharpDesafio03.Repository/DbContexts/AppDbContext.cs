using Microsoft.EntityFrameworkCore;

namespace RocketseatCSharpDesafio03.Repository.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Domain.Entities.Task> Tasks { get; set; }

    // Configuração para usar InMemory sem injeção de dependência
    public static AppDbContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TasksDb")
            .Options;

        return new AppDbContext(options);
    }
}
