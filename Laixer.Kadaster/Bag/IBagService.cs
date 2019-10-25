using Laixer.Kadaster.Entities;
using System.Collections.Generic;

namespace Laixer.Kadaster.Bag
{
    /// <summary>
    /// Toplevel bag service interface.
    /// </summary>
    public interface IBagService { }

    /// <summary>
    /// Bag service interface.
    /// </summary>
    /// <typeparam name="TEntity">Entity to return.</typeparam>
    public interface IBagService<TEntity> : IBagService
    {
        /// <summary>
        /// Return all instances of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns>
        IEnumerable<BagObject<TEntity>> GetAll(int limit = 0);

        /// <summary>
        /// Return a singe entity of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <param name="id">Entity identifier.</param>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns>
        BagObject<TEntity> GetById(BagId id);
    }
}
