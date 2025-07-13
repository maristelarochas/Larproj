using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Larproj.Application.Dtos;

public class CreateUserOutputDto()
{
    public required string Token { get; set; }
}