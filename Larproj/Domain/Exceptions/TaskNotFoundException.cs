using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Larproj.Domain.Exceptions;

public class TaskNotFoundException : Exception
{
    public TaskNotFoundException () : base ("Não foi possível encontrar a tarefa") {}
}
