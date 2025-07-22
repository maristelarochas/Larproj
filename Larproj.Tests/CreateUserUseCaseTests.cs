using Larproj.Application.Dtos;
using Larproj.Application.UseCases.CreateUser;
using Larproj.Domain.Entities;
using Larproj.Infrastruture.Repositories;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace LarProj.Tests;

[TestClass]
public sealed class CreateUserUseCaseTests
{
    [TestMethod]
    public async Task Should_ReturnToken_When_UserCreated()
    {

        var input = new CreateUserInputDto()
        {
            Name = "John ",
            Email = "johndoe@email.com",
            HashPassword = "salnsakalsns0"
        };

        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(r => r.Add(It.IsAny<User>()));

        var useCase = new CreateUserUseCase(userRepositoryMock.Object);
        var result = await useCase.Execute(input);

        userRepositoryMock.Verify(r => r.Add(It.IsAny<User>()), Times.AtLeastOnce());

        Assert.IsNotNull(result);
    }
}