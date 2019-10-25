using Laixer.Kadaster.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Laixer.Kadaster.Bag
{
    /// <summary>
    /// City service.
    /// </summary>
    public class CityService : ServiceBase<City>
    {
        public CityService(IRemoteProcedure remoteProcedure)
            : base(remoteProcedure)
        {
        }

        private class CityList
        {
            [JsonProperty("woonplaatsen")]
            public IList<City> Cities { get; set; } = new List<City>();
        }

        /// <summary>
        /// Return all instances of type <see cref="City"/>.
        /// </summary>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns>
        public override IEnumerable<BagObject<City>> GetAll(int limit = 0)
        {
            int page = 1;
            int itemCount = 0;

            do
            {
                var data = _remoteProcedure.Query<ApplicationLanguage<CityList>>($"woonplaatsen?page={page}");
                foreach (var item in data.Embed.Cities)
                {
                    if (limit > 0 && itemCount == limit)
                    {
                        yield break;
                    }

                    ++itemCount;
                    yield return ItemAsBagObject(item);
                }

                if (data.Embed.Cities.Count == 0)
                {
                    yield break;
                }

                ++page;
            } while (true);
        }

        private BagObject<City> ItemAsBagObject(City item)
        {
            item.GeoJson = JsonConvert.SerializeObject(item.Embed.Geometry);

            return new BagObject<City>
            {
                Value = item
            };
        }

        /// <summary>
        /// Return a singe entity of type <see cref="City"/>.
        /// </summary>
        /// <param name="id">Entity identifier.</param>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns
        public override BagObject<City> GetById(BagId id) => ItemAsBagObject(_remoteProcedure.Query<City>($"woonplaatsen/{id}"));
    }
}
