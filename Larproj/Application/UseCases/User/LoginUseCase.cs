using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Larproj.Domain.Entities;
using Larproj.Domain.Exceptions;
using Larproj.Infrastruture.Repositories;

namespace Larproj.Application.UseCases;

public interface ILoginUseCase
{
    public Task<LoginOutputDto> Execute(LoginInputDto input);
}
public class LoginUseCase(IUserRepository userRepository) : ILoginUseCase
{
    public async Task<LoginOutputDto> Execute(LoginInputDto input)
    {
        var user = await userRepository.GetByEmail(input.Email);
        if (input.Email != user?.Email)
            throw new InvalidEmailException(input.Email);

        if (user.HashPassword != input.HashPassword)
            throw new InvalidHashException();
            
        return new LoginOutputDto { Id = user.Id };
    }   
}

public class LoginInputDto()
{
    public required string Email { get; set; }
    public required string HashPassword { get; set; }
}

public class LoginOutputDto()
{
    public required int Id { get; set; }
}