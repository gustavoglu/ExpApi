using Exp.Domain.Core.Models;
using System;
using System.Threading.Tasks;

namespace Exp.UWP.Interfaces
{
    public interface IWSEntityService<T> where T : Entity
    {
        Task<bool> Cria(T entity);
        Task<bool> Atualiza(T entity);
        Task<bool> Deleta(Guid id);
    }
}
