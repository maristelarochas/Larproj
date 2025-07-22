using Larproj.Domain.Entities;
using Larproj.Domain.Exceptions;
using Larproj.Infrastruture.Persistence;

namespace Larproj.Infrastruture.Repositories;

public interface ITaskRepository
{
    Task Add(LarTask larTask);
    Task<LarTask> Get(int id);
    Task Update(LarTask larTask);
    Task Delete(LarTask larTask);
}
public class TaskRepository(DataContext dataContext) : ITaskRepository
{
    public async Task Add(LarTask newTask)
    {
        await dataContext.LarTasks.AddAsync(newTask);
        await dataContext.SaveChangesAsync();
    }
    public async Task<LarTask> Get(int id)
    {
        return await dataContext.LarTasks.FindAsync(id);
    }
    public async Task Update(LarTask larTask)
    {
        dataContext.LarTasks.Update(larTask);
        await dataContext.SaveChangesAsync();
    }
    public async Task Delete(LarTask larTask)
    {
        dataContext.LarTasks.Remove(larTask);
        await dataContext.SaveChangesAsync();
    }
}