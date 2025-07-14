using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Larproj.Application.Dtos;

public class CreateUserInputDto()
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string HashPassword { get; set; }
    public int CurrentScore { get; set; }
    public int PartyId { get; set; }
}