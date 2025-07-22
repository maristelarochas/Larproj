using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Larproj.Domain.Exceptions
{
    public class InvalidHashException : Exception
    {
        public InvalidHashException() : base ("Senha Inválida") {}
    }
}