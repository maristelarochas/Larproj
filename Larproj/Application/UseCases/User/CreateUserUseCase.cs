using Larproj.Application.Dtos;
using Larproj.Domain.Entities;
using Larproj.Domain.Exceptions;
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
        var existingUser = await userRepository.GetByEmail(input.Email);
        if (existingUser != null)
            throw new EmailAlreadyExistsException(input.Email);

        var newUser = new User(
            id: 0,
            name: input.Name,
            email: input.Email,
            hashPassword: input.HashPassword,
            currentScore: 0,
            partyId: null
        );

        await userRepository.Add(newUser);
        return new CreateUserOutputDto { Id = newUser.Id };
    }
}