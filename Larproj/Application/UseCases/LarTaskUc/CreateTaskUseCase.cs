using Larproj.Domain.Entities;
using Larproj.Infrastruture.Repositories;

namespace Larproj.Application.UseCases.LarTaskUc;

public interface ICreateTaskUseCase
{
    public Task<CreateTaskOutputDto> Execute(CreateTaskInputDto input);
}
public class CreateTaskUseCase(ITaskRepository taskRepository) : ICreateTaskUseCase
{
    public async Task<CreateTaskOutputDto> Execute(CreateTaskInputDto input)
    {
        var newTask = new LarTask(
            title: input.Title,
            description: input.Description,
            deadline: input.Deadline
        );
        await taskRepository.Add(newTask);

        return new CreateTaskOutputDto()
        {
            Id = newTask.Id
        };
    }
}
public class CreateTaskInputDto()
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime Deadline { get; set; }
}
public class CreateTaskOutputDto()
{
    public int Id { get; set; }
}