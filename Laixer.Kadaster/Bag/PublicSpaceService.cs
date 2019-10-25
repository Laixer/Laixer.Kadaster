using Laixer.Kadaster.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Laixer.Kadaster.Bag
{
    /// <summary>
    /// Public space service.
    /// </summary>
    public class PublicSpaceService : ServiceBase<PublicSpace>
    {
        public PublicSpaceService(IRemoteProcedure remoteProcedure)
            : base(remoteProcedure)
        {
        }

        private class PublicSpaceList
        {
            [JsonProperty("openbareRuimtes")]
            public IList<PublicSpace> PublicSpaces { get; set; } = new List<PublicSpace>();
        }

        /// <summary>
        /// Return all instances of type <see cref="PublicSpace"/>.
        /// </summary>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns>
        public override IEnumerable<BagObject<PublicSpace>> GetAll(int limit = 0)
        {
            int page = 1;
            int itemCount = 0;

            do
            {
                var data = _remoteProcedure.Query<ApplicationLanguage<PublicSpaceList>>($"openbare-ruimtes?page={page}");
                foreach (var item in data.Embed.PublicSpaces)
                {
                    if (limit > 0 && itemCount == limit)
                    {
                        yield break;
                    }

                    ++itemCount;
                    yield return ItemAsBagObject(item);
                }

                if (data.Embed.PublicSpaces.Count == 0)
                {
                    yield break;
                }

                page++;
            } while (true);
        }

        private BagObject<PublicSpace> ItemAsBagObject(PublicSpace item)
        {
            return new BagObject<PublicSpace>
            {
                Value = item
            };
        }

        /// <summary>
        /// Return a singe entity of type <see cref="PublicSpace"/>.
        /// </summary>
        /// <param name="id">Entity identifier.</param>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns
        public override BagObject<PublicSpace> GetById(BagId id) => ItemAsBagObject(_remoteProcedure.Query<PublicSpace>($"openbare-ruimtes/{id}"));
    }
}
