using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Larproj.Domain.Exceptions;

public class InvalidEmailException : Exception
{
        public InvalidEmailException(string email) : base($"Email {email} inválido") {}
}
