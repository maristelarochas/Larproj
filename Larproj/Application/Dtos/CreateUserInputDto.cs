using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Larproj.Application.Dtos;

public class CreateUserInputDto()
{
    public int UserId { get; set; }
    public required string UserName { get; set; }
    public required string UserEmail { get; set; }
    public required string UserHashPassword { get; set; }
}