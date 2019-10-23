using Laixer.Kadaster.Entities;
using RestSharp;
using System.Collections.Generic;

namespace Laixer.Kadaster.Bag
{
    public class DesignationService : IBagService<Designation>
    {
        private readonly IRestClient _client;

        public DesignationService(IRestClient client)
        {
            _client = client;
        }

        public class MySource
        {
            public Source bron { get; set; }
        }

        public class HalOccurrence : Occurrence
        {
            public MySource _embedded { get; set; }
        }

        public class HalDesignation : Designation
        {
            public class ValidOccurrence
            {
                public HalOccurrence geldigVoorkomen { get; set; }
            }

            public ValidOccurrence _embedded { get; set; }
            public dynamic _links { get; set; }
        }

        public class DesignationList
        {
            public IList<HalDesignation> nummeraanduidingen { get; set; } = new List<HalDesignation>();
        }

        public IEnumerable<BagObject<Designation>> GetAll(int limit = 0)
        {
            int page = 1;

            do
            {
                var request = new RestRequest("nummeraanduidingen");
                request.AddParameter("page", page);
                System.Console.WriteLine($"page: {page}");

                var response = _client.Get<ApplicationLanguage<DesignationList>>(request);

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    if (response.Content.Contains("CANNOT_RETURN_MORE_THAN_10000_RESULTS"))
                    {
                        throw new System.Exception("Max objecten reached");
                    }
                }

                foreach (var item in response.Data._embedded.nummeraanduidingen)
                {
                    yield return new BagObject<Designation>
                    {
                        Value = item as Designation
                    };
                }

                if (response.Data._embedded.nummeraanduidingen.Count == 0)
                {
                    yield break;
                }

                page++;
            } while (true);
        }

        public IEnumerable<BagObject<Designation>> GetAll(string postcode, int? houseNumber = null)
        {
            int page = 1;

            do
            {
                var request = new RestRequest("nummeraanduidingen");
                request.AddParameter("postcode", postcode);
                if (houseNumber.HasValue)
                {
                    request.AddParameter("huisnummer", houseNumber);
                }
                request.AddParameter("page", page);

                var response = _client.Get<ApplicationLanguage<DesignationList>>(request);

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    if (response.Content.Contains("CANNOT_RETURN_MORE_THAN_10000_RESULTS"))
                    {
                        throw new System.Exception("Max objecten reached");
                    }
                }

                foreach (var item in response.Data._embedded.nummeraanduidingen)
                {
                    yield return new BagObject<Designation>
                    {
                        Value = item as Designation
                    };
                }

                if (response.Data._embedded.nummeraanduidingen.Count == 0)
                {
                    yield break;
                }

                page++;
            } while (true);
        }

        public BagObject<Designation> GetById(BagId id)
        {
            var request = new RestRequest("nummeraanduidingen/{id}");
            request.AddUrlSegment("id", id);

            var response = _client.Get<Designation>(request);

            return new BagObject<Designation>
            {
                Value = response.Data as Designation
            };
        }
    }
}
