namespace Larproj.Application.Dtos;

public class CreateUserInputDto()
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string HashPassword { get; set; }
}