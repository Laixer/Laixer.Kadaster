using Laixer.Kadaster.Entities;
using System.Collections.Generic;

namespace Laixer.Kadaster.Bag
{
    /// <summary>
    /// Service base.
    /// </summary>
    /// <typeparam name="TEntity">Entity.</typeparam>
    public abstract class ServiceBase<TEntity> : IBagService<TEntity>
    {
        protected readonly IRemoteProcedure _remoteProcedure;

        /// <summary>
        /// Create new instance.
        /// </summary>
        /// <param name="remoteProcedure">Instance of <see cref="IRemoteProcedure"/>.</param>
        public ServiceBase(IRemoteProcedure remoteProcedure)
        {
            _remoteProcedure = remoteProcedure;
        }

        /// <summary>
        /// Return all instances of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns>
        public abstract IEnumerable<BagObject<TEntity>> GetAll(int limit = 0);

        /// <summary>
        /// Return a singe entity of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="id">Entity identifier.</param>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns>
        public abstract BagObject<TEntity> GetById(BagId id);

        /// <summary>
        /// Return a singe entity of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="id">Entity identifier.</param>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns>
        public BagObject<TEntity> GetById(string id) => GetById(new BagId(id));

        protected virtual BagObject<TEntity> ItemAsBagObject(TEntity item)
            => new BagObject<TEntity>
            {
                Value = item
            };

        protected virtual BagObject<TEntity> GetById(BagId id, string uri)
            => ItemAsBagObject(_remoteProcedure.Query<TEntity>(uri));
    }
}
