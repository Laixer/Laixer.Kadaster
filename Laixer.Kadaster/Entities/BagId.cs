namespace Laixer.Kadaster.Entities
{
    /// <summary>
    /// BAG Entity identifier.
    /// </summary>
    public class BagId
    {
        private readonly string _id;

        /// <summary>
        /// Create new instance.
        /// </summary>
        /// <param name="id">Identifier as string.</param>
        public BagId(string id)
        {
            // FUTURE: There are more checks that can be done on an BAG id

            if (id.Length != 16)
            {
                throw new System.Exception("INVAL"); // TODO
            }

            _id = id;
        }

        /// <summary>
        /// Present identifier as string.
        /// </summary>
        /// <returns>Identifier as string.</returns>
        public override string ToString() => _id;
    }
}
