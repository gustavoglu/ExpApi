using Exp.Domain.Interfaces.Repository;
using Exp.Domain.Models;
using Exp.Infra.Data.Context;

namespace Exp.Infra.Data.Repository
{
    public class ContaEnderecoRepository : Repository<ContaEndereco>, IContaEnderecoRepository
    {
        public ContaEnderecoRepository(ContextSQLS context) : base(context)
        {
        }
    }
}
