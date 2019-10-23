using Laixer.Kadaster.Entities;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace Laixer.Kadaster.Bag
{
    public class PremiseService : IBagService<Premise>
    {
        private readonly IRestClient _client;

        public PremiseService(IRestClient client)
        {
            _client = client;
        }

        public class HalPremise : Premise
        {
            public class Embedded
            {
                public dynamic geometrie { get; set; }
            }

            public Embedded _embedded { get; set; }
            public dynamic _links { get; set; }
        }

        public class PremiseList
        {
            public IList<HalPremise> panden { get; set; } = new List<HalPremise>();
        }

        public IEnumerable<BagObject<Premise>> GetAll()
        {
            int page = 1;

            do
            {
                var r = new
                {
                    geometrie = new
                    {
                        within = new
                        {
                            type = "Polygon",
                            coordinates = new double[,,]
{{{4.3818283, 51.9497670},
{4.4125557, 51.9485503},
{4.4517803, 51.9715044},
{4.4211388, 51.9935484},
{4.3368530, 51.9736723},
{4.3562722, 51.9442517},
{4.3818283, 51.9497670}}}
                        }
                    }
                };

                var ttx = JsonConvert.SerializeObject(r);

                var request = new RestRequest("panden");
                request.AddParameter("page", page, ParameterType.QueryString);
                //request.AddBody();
                //request.JsonSerializer = new RestSharpJsonNetSerializer();

                request.AddParameter("application/json", ttx, ParameterType.RequestBody);

                System.Console.WriteLine($"page: {page}");

                var response = _client.Post<ApplicationLanguage<PremiseList>>(request);

                //var response = _client.Get<ApplicationLanguage<PremiseList>>(request);
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    if (response.Content.Contains("CANNOT_RETURN_MORE_THAN_10000_RESULTS"))
                    {
                        throw new System.Exception("Max objecten reached");
                    }
                }
                foreach (var item in response.Data._embedded.panden)
                {
                    item.GeoJson = JsonConvert.SerializeObject(item._embedded.geometrie);
                    if (item.oorspronkelijkBouwjaar > 2100)
                    {
                        item.oorspronkelijkBouwjaar = null;
                    }
                    else if (item.oorspronkelijkBouwjaar == 0)
                    {
                        item.oorspronkelijkBouwjaar = null;
                    }

                    yield return new BagObject<Premise>
                    {
                        Value = item as Premise
                    };
                }

                if (response.Data._embedded.panden.Count == 0)
                {
                    yield break;
                }

                page++;
            } while (true);
        }

        public BagObject<Premise> GetById(string id)
        {
            var request = new RestRequest("panden/{id}");
            request.AddUrlSegment("id", id);

            var response = _client.Get<HalPremise>(request);

            var item = response.Data;

            item.GeoJson = JsonConvert.SerializeObject(response.Data._embedded.geometrie);
            if (item.oorspronkelijkBouwjaar > 2100)
            {
                item.oorspronkelijkBouwjaar = null;
            }

            return new BagObject<Premise>
            {
                Value = item as Premise
            };
        }
    }
}
