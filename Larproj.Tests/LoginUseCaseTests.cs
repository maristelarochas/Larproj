using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Larproj.Application.UseCases;
using Larproj.Domain.Entities;
using Larproj.Infrastruture.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LarProj.Tests;

[TestClass]
public class LoginUseCaseTests
{
    [TestMethod]
    public async Task Should_ReturnId_When_CredentialsAreValid()
    {
        var email = "johndoe@email.com";
        var hashPassword = "farsk-12a#s-sDdN";

        var user = new User
        (
            id: 12,
            name: "John Doe",
            email: "johndoe@email.com",
            hashPassword: "farsk-12a#s-sDdN",
            currentScore: 1000,
            partyId: null
        );

        var input = new LoginInputDto()
        {
            Email = email,
            HashPassword = hashPassword
        };

        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(r => r.GetByEmail(input.Email)).ReturnsAsync(user);

        var useCase = new LoginUseCase(userRepositoryMock.Object);

        var result = await useCase.Execute(input);
    }
}
