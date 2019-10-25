namespace Laixer.Kadaster.Bag
{
    /// <summary>
    /// Bag object for entity.
    /// </summary>
    /// <typeparam name="TEntity">Entity.</typeparam>
    public class BagObject<TEntity>
    {
        /// <summary>
        /// Value of <typeparamref name="TEntity"/>.
        /// </summary>
        public TEntity Value { get; set; }
    }
}
