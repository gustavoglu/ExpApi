using Exp.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Exp.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : Entity
    {
        T Criar(T entity);
        T Atualizar(T entity);
        T Deletar(Guid id);
        T TrazerPorId(Guid id);
        IEnumerable<T> TrazerTodos();
        IEnumerable<T> TrazerTodosAtivos();
        IEnumerable<T> TrazerTodosDeletados();
        IEnumerable<T> Pesquisar(Expression<Func<T,bool>> predicate);
    }
}
