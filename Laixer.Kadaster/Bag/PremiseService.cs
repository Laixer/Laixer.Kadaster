using Laixer.Kadaster.Entities;
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
            public class ValidOccurrence
            {
                public dynamic geldigVoorkomen { get; set; }
            }

            public ValidOccurrence _embedded { get; set; }
            public dynamic _links { get; set; }
        }

        public class PremiseList
        {
            public IList<HalPremise> nummeraanduidingen { get; set; } = new List<HalPremise>();
        }

        public IEnumerable<BagObject<Premise>> GetAll()
        {
            int page = 0;

            do
            {
                var request = new RestRequest("panden");
                request.AddParameter("page", page);

                var response = _client.Get<ApplicationLanguage<PremiseList>>(request);
                foreach (var item in response.Data._embedded.nummeraanduidingen)
                {
                    yield return new BagObject<Premise>
                    {
                        Value = item as Premise
                    };
                }

                if (response.Data._embedded.nummeraanduidingen.Count == 0)
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

            var response = _client.Get<Premise>(request);

            return new BagObject<Premise>
            {
                Value = response.Data as Premise
            };
        }
    }
}
