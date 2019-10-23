using Laixer.Kadaster.Entities;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace Laixer.Kadaster.Bag
{
    public class CityService : IBagService<City>
    {
        private readonly IRestClient _client;

        public CityService(IRestClient client)
        {
            _client = client;
        }

        public class HalCity : City
        {
            public class Embedded
            {
                public dynamic geometrie { get; set; }
            }

            public Embedded _embedded { get; set; }
            public dynamic _links { get; set; }
        }

        public class CityList
        {
            public IList<HalCity> woonplaatsen { get; set; } = new List<HalCity>();
        }

        public IEnumerable<BagObject<City>> GetAll()
        {
            int page = 1;

            do
            {
                var request = new RestRequest("woonplaatsen");
                request.AddParameter("page", page);

                var response = _client.Get<ApplicationLanguage<CityList>>(request);
                foreach (var item in response.Data._embedded.woonplaatsen)
                {
                    item.GeoJson = JsonConvert.SerializeObject(item._embedded.geometrie);

                    yield return new BagObject<City>
                    {
                        Value = item as City
                    };
                }

                if (response.Data._embedded.woonplaatsen.Count == 0)
                {
                    yield break;
                }

                ++page;
            } while (true);
        }

        public BagObject<City> GetById(string id)
        {
            var request = new RestRequest("woonplaatsen/{id}");
            request.AddUrlSegment("id", id);

            var response = _client.Get<City>(request);

            return new BagObject<City>
            {
                Value = response.Data as City
            };
        }
    }
}
