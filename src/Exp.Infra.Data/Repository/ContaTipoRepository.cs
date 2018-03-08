using Exp.Domain.Interfaces.Repository;
using Exp.Domain.Models;
using Exp.Infra.Data.Context;

namespace Exp.Infra.Data.Repository
{
    public class ContaTipoRepository : Repository<ContaTipo>, IContaTipoRepository
    {
        public ContaTipoRepository(ContextSQLS context) : base(context)
        {
        }
    }
}
