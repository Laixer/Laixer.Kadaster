using Laixer.Kadaster.Entities;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace Laixer.Kadaster.Bag
{
    public class PremiseService : ServiceBase<Premise>
    {
        private readonly IRemoteProcedure remoteProcedure;

        public PremiseService(IRestClient client, IRemoteProcedure remoteProcedure)
            : base(client)
        {
            this.remoteProcedure = remoteProcedure;
        }

        public class HalPremise : Premise
        {
            public class Embedding
            {
                public dynamic geometrie { get; set; }
            }

            [JsonProperty("_embedded")]
            public Embedding Embedded { get; set; }

            [JsonProperty("_links")]
            public dynamic Links { get; set; }
        }

        public class PremiseList
        {
            [JsonProperty("panden")]
            public IList<HalPremise> Premises { get; set; } = new List<HalPremise>();
        }

        public override IEnumerable<BagObject<Premise>> GetAll(int limit = 0)
        {
            int page = 1;
            int itemCounter = 0;

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

                //var ttx = JsonConvert.SerializeObject(r);

                System.Console.WriteLine($"page: {page}");

                var data = remoteProcedure.Execute<ApplicationLanguage<PremiseList>>($"panden?page={page}", r);

                //if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                //{
                //    if (response.Content.Contains("CANNOT_RETURN_MORE_THAN_10000_RESULTS"))
                //    {
                //        throw new System.Exception("Max objecten reached");
                //    }
                //}

                foreach (var item in data._embedded.Premises)
                {
                    if (limit > 0 && limit == itemCounter)
                    {
                        yield break;
                    }

                    ++itemCounter;
                    yield return ItemAsBagObject(item);
                }

                if (data._embedded.Premises.Count == 0)
                {
                    yield break;
                }

                page++;
            } while (true);
        }

        private BagObject<Premise> ItemAsBagObject(HalPremise item)
        {
            item.GeoJson = JsonConvert.SerializeObject(item.Embedded.geometrie);
            if (item.oorspronkelijkBouwjaar > 2100)
            {
                item.oorspronkelijkBouwjaar = null;
            }
            else if (item.oorspronkelijkBouwjaar == 0)
            {
                item.oorspronkelijkBouwjaar = null;
            }

            return new BagObject<Premise>
            {
                Value = item as Premise
            };
        }

        public override BagObject<Premise> GetById(BagId id)
        {
            return ItemAsBagObject(remoteProcedure.Query<HalPremise>($"panden/{id}"));
        }
    }
}
