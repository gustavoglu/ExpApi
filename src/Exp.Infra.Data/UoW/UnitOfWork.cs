using Exp.Domain.Interfaces.UoW;
using Exp.Infra.Data.Context;

namespace Exp.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextSQLS _context;
        public UnitOfWork(ContextSQLS context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
