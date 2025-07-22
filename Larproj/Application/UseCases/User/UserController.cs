using Larproj.Application.Dtos;
using Larproj.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Larproj.Application.UseCases.CreateUser;

[ApiController]
[Route("api/[controller]")]
public class UserController (ICreateUserUseCase createUserUseCase) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserInputDto input)
    {
        try
        {
            var output = await createUserUseCase.Execute(input);
            return Ok(output);
        }
        catch (EmailAlreadyExistsException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }
}
