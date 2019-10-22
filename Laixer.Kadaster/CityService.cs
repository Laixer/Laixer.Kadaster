using Laixer.Kadaster.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Laixer.Kadaster
{
    public class CityService : IBagService
    {
        private readonly IRestClient _client;

        public CityService(IRestClient client)
        {
            _client = client;
        }

        public class CityList
        {
            public IList<City> woonplaatsen { get; set; } = new List<City>();
        }

        public async Task<object> GetAllAsync()
        {
            int page = 0;
            List<City> cityList = new List<City>();

            do
            {
                var request = new RestRequest("woonplaatsen");
                request.AddParameter("page", page);

                var response = await _client.ExecuteGetTaskAsync<ApplicationLanguage<CityList>>(request);

                if (response.Data._embedded.woonplaatsen.Count == 0)
                {
                    return cityList;
                }

                cityList.AddRange(response.Data._embedded.woonplaatsen);

                page++;
            } while (true);

            throw new NotImplementedException();
        }

        public Task<object> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
