using Laixer.Kadaster.Entities;
using System.Collections.Generic;

namespace Laixer.Kadaster.Bag
{
    public interface IBagService { }

    public interface IBagService<TEntity> : IBagService
    {
        /// <summary>
        /// Return all instances of <see cref="BagObject{T}"/>.
        /// </summary>
        /// <returns></returns>
        IEnumerable<BagObject<TEntity>> GetAll(int limit = 0);

        /// <summary>
        /// Return a singe entity of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="id">Entity identifier.</param>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns>
        BagObject<TEntity> GetById(BagId id);
    }
}
