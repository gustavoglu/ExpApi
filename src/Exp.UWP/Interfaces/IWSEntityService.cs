using Exp.Domain.Core.Models;
using System;
using System.Threading.Tasks;

namespace Exp.UWP.Interfaces
{
    public interface IWSEntityService<T> where T : Entity
    {
        Task Cria(T entity);
        Task Atualiza(T entity);
        Task Deleta(Guid id);
    }
}
