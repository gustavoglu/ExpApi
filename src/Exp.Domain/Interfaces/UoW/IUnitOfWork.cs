namespace Exp.Domain.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
