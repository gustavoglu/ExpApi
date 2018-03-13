using Exp.Domain.Models;
using System;
using System.Collections.Generic;

namespace Exp.Application.Interfaces
{
    public interface IClienteService
    {
        Cliente Criar(Cliente cliente);
        Cliente Atualizar(Cliente entity);
        Cliente Deletar(Guid id);
        Cliente TrazerPorId(Guid id);
        IEnumerable<Cliente> TrazerTodosAtivos();
        IEnumerable<Cliente> TrazerTodosDeletados();
    }
}
