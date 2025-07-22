using System.Diagnostics;
using Larproj.Application.UseCases.LarTaskUc;
using Larproj.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LarProj.Tests;

[TestClass]
public class CreateTaskUseCaseTests
{
    [TestMethod]
    public async Task Should_ReturnTaskId_When_TaskIsCreated()
    {
        var input = new CreateTaskInputDto()
        {
            Title = "Lavar o banheiro",
            Description = "Atenção ao box",
            Deadline = DateTime.Today,
            Conclusion = DateTime.Today,
        };

        var newTask = new LarTask(
            title: input.Title,
            description: input.Description,
            deadline: input.Deadline,
            conclusionDate: input.Conclusion
        );

        var taskRepositoryMock = new Mock<ITaskRepository>();
        taskRepositoryMock.Setup(r => r.Add(newTask));

        var useCase = new CreateTaskUseCase(taskRepositoryMock.Object);
        var result = await useCase.Execute(input);

        Assert.IsNotNull(result);
    }
}