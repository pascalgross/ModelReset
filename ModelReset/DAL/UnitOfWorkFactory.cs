using ModelReset.Contracts;

namespace ModelReset.DAL
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ApplicationContext _applicationContext;

        public UnitOfWorkFactory(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(_applicationContext);
        }
    }
}