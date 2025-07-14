using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Larproj.Application.Dtos;
using Larproj.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Larproj.Application.UseCases.CreateUser;

[ApiController]
[Route("api/[controller]")]
public class UserController (ICreateUserUseCase createUserUseCase) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserInputDto input)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var output = await createUserUseCase.Execute(input);
            return Ok(output);
        }
        catch (EmailAlreadyExistsException ex)
        {
            return Conflict(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ocorreu um erro interno ao criar o usuário: {ex.Message}");
        }
    }

    // public IActionResult Index()
    // {
    //     return View();
    // }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View("Error!");
    // }
}
