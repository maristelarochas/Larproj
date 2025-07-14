using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Larproj.Domain.Exceptions;
public class EmailAlreadyExistsException : Exception
{
    public EmailAlreadyExistsException(string email) : base($"O email {email} já está cadastrado") {}
}
