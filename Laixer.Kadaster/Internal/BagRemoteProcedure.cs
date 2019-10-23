using RestSharp;
using System;

namespace Laixer.Kadaster.Internal
{
    internal class BagRemoteProcedure : IRemoteProcedure
    {
        private readonly IRestClient client;

        public IJsonSerialzer JsonSerialzer { get; set; }

        public BagRemoteProcedure(string baseUrl, string apiKey)
        {
            client = new RestClient(baseUrl);
            client.AddDefaultHeader("X-Api-Key", apiKey);
            client.AddDefaultHeader("Accept", "application/hal+json");
        }

        public string Query(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentNullException(nameof(uri));
            }

            var response = client.Execute(new RestRequest(uri), Method.GET);

            // TODO: Handle response

            return response.Content;
        }

        public TReturn Query<TReturn>(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentNullException(nameof(uri));
            }

            if (JsonSerialzer == null)
            {
                throw new NullReferenceException(nameof(JsonSerialzer));
            }

            return JsonSerialzer.DeserializeObject<TReturn>(Query(uri));
        }

        public string Execute(string uri, object obj)
        {
            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentNullException(nameof(uri));
            }

            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (JsonSerialzer == null)
            {
                throw new NullReferenceException(nameof(JsonSerialzer));
            }

            var request = new RestRequest(uri);
            request.AddParameter("application/json", JsonSerialzer.SerializeObject(obj), ParameterType.RequestBody);
            var response = client.Execute(request, Method.POST);

            // TODO: Handle response

            return response.Content;
        }

        public TReturn Execute<TReturn>(string uri, object obj)
        {
            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentNullException(nameof(uri));
            }

            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (JsonSerialzer == null)
            {
                throw new NullReferenceException(nameof(JsonSerialzer));
            }

            return JsonSerialzer.DeserializeObject<TReturn>(Execute(uri, obj));
        }
    }
}
