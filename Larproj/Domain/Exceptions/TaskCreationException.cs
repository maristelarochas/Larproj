using System;

namespace Larproj.Domain.Exceptions;

public class TaskCreationException : Exception
{
    public TaskCreationException(string title) : base($"Não foi possível criar a tarefa {title}") { }
}
