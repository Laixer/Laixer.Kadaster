namespace Laixer.Kadaster.Entities
{
    /// <summary>
    /// BAG Entity identifier.
    /// </summary>
    public class BagId
    {
        private string _id;

        public BagId(string id)
        {
            if (id.Length != 16)
            {
                throw new System.Exception("INVAL");
            }

            _id = id;
        }

        public override string ToString() => _id;
    }
}
