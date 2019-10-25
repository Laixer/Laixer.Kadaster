using Laixer.Kadaster.Entities;
using RestSharp;
using System.Collections.Generic;

namespace Laixer.Kadaster.Bag
{
    public abstract class ServiceBase<TEntity> : IBagService<TEntity>
    {
        protected readonly IRemoteProcedure _remoteProcedure;

        public ServiceBase(IRemoteProcedure remoteProcedure)
        {
            _remoteProcedure = remoteProcedure;
        }

        public abstract IEnumerable<BagObject<TEntity>> GetAll(int limit = 0);
        public abstract BagObject<TEntity> GetById(BagId id);

        public BagObject<TEntity> GetById(string id) => GetById(new BagId(id));
    }
}
