using Exp.Domain.Interfaces.Repository;
using Exp.Domain.Models;
using Exp.Infra.Data.Context;

namespace Exp.Infra.Data.Repository
{
    public class ColaboradorRepository : Repository<Colaborador>, IColaboradorRepository
    {
        public ColaboradorRepository(ContextSQLS context) : base(context)
        {
        }
    }
}
