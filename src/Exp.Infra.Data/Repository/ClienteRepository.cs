using System;
using System.Collections.Generic;
using System.Linq;
using Exp.Domain.Interfaces.Repository;
using Exp.Domain.Models;
using Exp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Exp.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ContextSQLS context) : base(context)
        {
        }

        public override IEnumerable<Cliente> TrazerTodosAtivos()
        {
            return dbSet.Where(c => c.Deletado == false)
                .Include(c => c.Enderecos)
                .Include(c => c.Contatos);
        }

        public override Cliente TrazerPorId(Guid id)
        {
            return dbSet.Include(c => c.Enderecos)
                        .Include(c => c.Contatos)
                        .FirstOrDefault(c => c.Id == id);
        }
    }
}
