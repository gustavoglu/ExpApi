using Exp.Domain.Core.Models;
using Exp.Domain.Interfaces.Repository;
using Exp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Exp.Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected ContextSQLS _context;
        protected DbSet<T> dbSet;

        public Repository(ContextSQLS context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        public virtual T Atualizar(T entity)
        {
            dbSet.Update(entity);
            return entity;
        }

        public virtual T Criar(T entity)
        {
            dbSet.Add(entity);
            return entity;
        }

        public virtual T Deletar(Guid id)
        {
            var entity = this.TrazerPorId(id);
            dbSet.Remove(entity);
            return entity;
        }

        public IEnumerable<T> Pesquisar(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public virtual T TrazerPorId(Guid id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> TrazerTodos()
        {
            return dbSet;
        }

        public virtual IEnumerable<T> TrazerTodosAtivos()
        {
            return dbSet.Where(e => e.Deletado == false);
        }

        public virtual IEnumerable<T> TrazerTodosDeletados()
        {
            return dbSet.Where(e => e.Deletado == true);
        }
    }
}
