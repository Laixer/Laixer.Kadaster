using Laixer.Kadaster.Entities;
using RestSharp;
using System.Collections.Generic;

namespace Laixer.Kadaster.Bag
{
    public class PublicSpaceService : IBagService<PublicSpace>
    {
        private readonly IRestClient _client;

        public PublicSpaceService(IRestClient client)
        {
            _client = client;
        }

        public class HalPublicSpace : PublicSpace
        {
            public dynamic _embedded { get; set; }
            public dynamic _links { get; set; }
        }

        public class PublicSpaceList
        {
            public IList<HalPublicSpace> nummeraanduidingen { get; set; } = new List<HalPublicSpace>();
        }

        public IEnumerable<BagObject<PublicSpace>> GetAll()
        {
            int page = 1;

            do
            {
                var request = new RestRequest("openbare-ruimtes");
                request.AddParameter("page", page);
                System.Console.WriteLine($"page: {page}");

                var response = _client.Get<ApplicationLanguage<PublicSpaceList>>(request);

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    if (response.Content.Contains("CANNOT_RETURN_MORE_THAN_10000_RESULTS"))
                    {
                        throw new System.Exception("Max objecten reached");
                    }
                }

                foreach (var item in response.Data._embedded.nummeraanduidingen)
                {
                    yield return new BagObject<PublicSpace>
                    {
                        Value = item as PublicSpace
                    };
                }

                if (response.Data._embedded.nummeraanduidingen.Count == 0)
                {
                    yield break;
                }

                page++;
            } while (true);
        }

        public BagObject<PublicSpace> GetById(string id)
        {
            var request = new RestRequest("openbare-ruimtes/{id}");
            request.AddUrlSegment("id", id);

            var response = _client.Get<PublicSpace>(request);

            return new BagObject<PublicSpace>
            {
                Value = response.Data as PublicSpace
            };
        }
    }
}
