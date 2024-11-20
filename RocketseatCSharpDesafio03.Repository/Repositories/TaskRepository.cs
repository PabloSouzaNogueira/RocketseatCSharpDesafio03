using Microsoft.EntityFrameworkCore;
using RocketseatCSharpDesafio03.Repository.DbContexts;
using System.Collections.Generic;

namespace RocketseatCSharpDesafio03.Repository.Repositories;

public class TaskRepository
{
    private readonly AppDbContext _Db;

    public TaskRepository()
    {
        _Db = AppDbContext.CreateInMemoryContext();
    }

    public void Dispose()
    {
        _Db.Dispose();
        GC.SuppressFinalize(this);
    }

    public List<Domain.Entities.Task> GetAll()
    {
        return _Db.Tasks.ToList();
    }

    public Domain.Entities.Task? GetById(int id)
    {
        return _Db.Tasks.Where(x => x.Id == id).FirstOrDefault();
    }

    public int? Register(Domain.Entities.Task _task)
    {
        var task = _Db.Tasks.Add(_task);

        _Db.SaveChanges();

        return task.Entity.Id;
    }

    public int? Update(int id, Domain.Entities.Task _task)
    {
        _task.Id = id;
        var task = _Db.Tasks.Find(id);

        if (task == null)
            return null;

        var entry = _Db.Entry(task);
        entry.CurrentValues.SetValues(_task);

        _Db.SaveChanges();

        return _task.Id;
    }

    public int? DeleteById(int id)
    {
        var task = _Db.Tasks.Find(id);

        if (task == null)
            return null;

        _Db.Remove(task);

        _Db.SaveChanges();

        return task.Id;
    }
}