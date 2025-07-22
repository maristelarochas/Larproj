using Larproj.Application.Dtos;
using Larproj.Domain.Entities;
using Larproj.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Larproj.Application.UseCases.LarTaskUc;

[Route("api/[controller]")]
[ApiController]
public class TaskController(ICreateTaskUseCase createTaskUseCase,
                            IDeleteTaskUseCase deleteTaskUseCase) 
                            : Controller
{
    [HttpPost("create")]
    public async Task<ActionResult<CreateTaskOutputDto>> CreateTask(CreateTaskInputDto input)
    {
        try
        {
            var output = await createTaskUseCase.Execute(input);
            return Ok(output);
        }
        catch (TaskCreationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [HttpPost("delete")]
    public async Task DeleteTask(int id)
    {
        try
        {
            var output = deleteTaskUseCase.Execute(id);
            Ok(output);
        }
        catch (Exception)
        {
            NotFound(new { });
        }
    }
}