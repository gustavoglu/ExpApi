using Exp.Domain.Models;
using System;
using System.Collections.Generic;

namespace Exp.Application.Interfaces
{
    public interface IContaTipoService
    {
        ContaTipo Criar(ContaTipo cliente);
        ContaTipo Atualizar(ContaTipo entity);
        ContaTipo Deletar(Guid id);
        ContaTipo TrazerPorId(Guid id);
        IEnumerable<ContaTipo> TrazerTodosAtivos();
        IEnumerable<ContaTipo> TrazerTodosDeletados();
    }
}
