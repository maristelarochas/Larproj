using Larproj.Domain.Entities;
using Larproj.Infrastruture.Repositories;

namespace Larproj.Application.UseCases.LarTaskUc;

public interface IDeleteTaskUseCase
{
    Task Execute(int id);
}
public class DeleteTaskUseCase(ITaskRepository taskRepository) : IDeleteTaskUseCase
{
    public async Task Execute(int id)
    {
        LarTask foundTask = await taskRepository.Get(id);
        if (foundTask.Id != id)
            throw new Exception();

        await taskRepository.Delete(foundTask);
    }
}
public class DeleteTaskInputDto()
{
    public required int Id { get; set; }
}