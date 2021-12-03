
namespace ModelReset.Contracts
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}