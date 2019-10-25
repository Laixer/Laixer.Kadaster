using Laixer.Kadaster.Exception;
using RestSharp;
using System;

namespace Laixer.Kadaster.Internal
{
    /// <summary>
    /// Remote procedure for BAG endpoints.
    /// </summary>
    internal class BagRemoteProcedure : IRemoteProcedure
    {
        private readonly IRestClient client;

        private class ErrorMessage
        {
            public int code { get; set; }
            public string message { get; set; }
        }

        /// <summary>
        /// Json serializer.
        /// </summary>
        public IJsonSerialzer JsonSerialzer { get; set; }

        /// <summary>
        /// Create new instance.
        /// </summary>
        /// <param name="baseUrl">Base endoint.</param>
        /// <param name="apiKey">Authorization key.</param>
        public BagRemoteProcedure(string baseUrl, string apiKey)
        {
            client = new RestClient(baseUrl);
            client.AddDefaultHeader("X-Api-Key", apiKey);
            client.AddDefaultHeader("Accept", "application/hal+json");
        }

        /// <summary>
        /// Execute the call to endpoint and handle errors.
        /// </summary>
        /// <param name="request"><see cref="IRestRequest"/>.</param>
        /// <param name="method"><see cref="Method"/>.</param>
        /// <returns>Contents of procedure as string.</returns>
        protected string PerformCall(IRestRequest request, Method method)
        {
            var response = client.Execute(request, method);
            if (response.IsSuccessful)
            {
                return response.Content;
            }

            var error = JsonSerialzer.DeserializeObject<ErrorMessage>(response.Content);

            throw new RemoteProcedureException($"Error: {error.code}; Message: {error.message}");
        }

        public string Query(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentNullException(nameof(uri));
            }

            return PerformCall(new RestRequest(uri), Method.GET);
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

            return PerformCall(request, Method.POST);
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
