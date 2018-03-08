using Exp.Domain.Interfaces.Repository;
using Exp.Domain.Models;
using Exp.Infra.Data.Context;

namespace Exp.Infra.Data.Repository
{
    public class ContaContatoRepository : Repository<ContaContato>, IContaContatoRepository
    {
        public ContaContatoRepository(ContextSQLS context) : base(context)
        {
        }
    }
}
