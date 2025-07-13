using System.Security.Authentication;
using Larproj.Application.Dtos;
using Larproj.Domain.Entities;
using Larproj.Infrastruture.Repositories;

namespace Larproj.Application.UseCases.CreateUser;

public interface ICreateUserUseCase
{
    public Task<CreateUserOutputDto> Execute(CreateUserInputDto input);
}

public class CreateUserUseCase(IUserRepository userRepository) : ICreateUserUseCase
{
    public async Task<CreateUserOutputDto> Execute(CreateUserInputDto input)
    {
        var existingUser = await userRepository.GetUserByEmail(input.UserEmail);
        if (existingUser != null)
            throw new InvalidCredentialException();
        
        var newUser = new User(
            userId: 0,
            userName: input.UserName,
            userEmail: input.UserEmail,
            userHashPassword: input.UserHashPassword
        );

        await userRepository.AddUser(newUser);
        return new CreateUserOutputDto { Token = "success" };
    }
}