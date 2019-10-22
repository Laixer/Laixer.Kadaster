using Laixer.Kadaster.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Laixer.Kadaster
{
    public class DesignationService : IBagService
    {
        private readonly IRestClient _client;

        public DesignationService(IRestClient client)
        {
            _client = client;
        }

        Task<object> IBagService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Designation> GetAll()
        {
            int page = 0;

            do
            {
                var request = new RestRequest("nummeraanduidingen");
                request.AddParameter("page", page);

                var response = _client.Get<ApplicationLanguage<DesignationList>>(request);
                foreach (var item in response.Data._embedded.nummeraanduidingen)
                {
                    yield return item as Designation;
                }

                if (response.Data._embedded.nummeraanduidingen.Count == 0)
                {
                    yield break;
                }

                page++;
            } while (true);
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

        public IEnumerable<Designation> GetAll(string postcode, int houseNumber)
        {
            int page = 0;

            do
            {
                var request = new RestRequest("nummeraanduidingen");
                request.AddParameter("postcode", postcode);
                request.AddParameter("huisnummer", houseNumber);
                request.AddParameter("page", page);

                var response = _client.Get<ApplicationLanguage<DesignationList>>(request);
                foreach (var item in response.Data._embedded.nummeraanduidingen)
                {
                    yield return item as Designation;
                }

                if (response.Data._embedded.nummeraanduidingen.Count == 0)
                {
                    yield break;
                }

                page++;
            } while (true);
        }

        public async Task<object> GetByIdAsync(string id)
        {
            var request = new RestRequest("nummeraanduidingen/{id}");
            request.AddUrlSegment("id", id);

            var response = await _client.ExecuteGetTaskAsync<Designation>(request);

            throw new NotImplementedException();
        }
    }
}
