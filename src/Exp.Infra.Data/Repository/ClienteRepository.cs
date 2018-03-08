using Exp.Domain.Interfaces.Repository;
using Exp.Domain.Models;
using Exp.Infra.Data.Context;

namespace Exp.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ContextSQLS context) : base(context)
        {
        }
    }
}
