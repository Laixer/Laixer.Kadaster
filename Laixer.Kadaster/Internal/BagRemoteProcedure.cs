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
        /// Json object serializer. See <see cref="IJsonSerialzer"/>.
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
            switch (response.ResponseStatus)
            {
                case ResponseStatus.Completed:
                    if (response.IsSuccessful)
                    {
                        return response.Content;
                    }

                    if (!string.IsNullOrEmpty(response.Content))
                    {
                        // TODO: This is an assumption.
                        var error = JsonSerialzer.DeserializeObject<ErrorMessage>(response.Content);

                        throw new RemoteProcedureException($"Error: {error.code}; Message: {error.message}");
                    }
                    break;

                case ResponseStatus.Error:
                    throw new RemoteProcedureException(response.ErrorMessage);

                case ResponseStatus.TimedOut:
                    throw new RemoteProcedureTimeoutException();

                case ResponseStatus.Aborted:
                    throw new RemoteProcedureOperationAbortedException();
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Perform query with result based on uri.
        /// </summary>
        /// <param name="uri">Request uri.</param>
        /// <returns>Result as string, if any.</returns>
        public string Query(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentNullException(nameof(uri));
            }

            return PerformCall(new RestRequest(uri), Method.GET);
        }

        /// <summary>
        /// Perform query with result based on uri.
        /// </summary>
        /// <typeparam name="TReturn">Return type.</typeparam>
        /// <param name="uri">Request uri.</param>
        /// <returns>Object of type <typeparamref name="TReturn"/>.</returns>
        public TReturn Query<TReturn>(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentNullException(nameof(uri));
            }

            if (JsonSerialzer == null)
            {
                throw new NotImplementedException(nameof(JsonSerialzer));
            }

            return JsonSerialzer.DeserializeObject<TReturn>(Query(uri));
        }

        /// <summary>
        /// Execute request and result result.
        /// </summary>
        /// <param name="uri">Request uri.</param>
        /// <param name="obj">Object to submit.</param>
        /// <returns>Result as string, if any.</returns>
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
                throw new NotImplementedException(nameof(JsonSerialzer));
            }

            var request = new RestRequest(uri);
            request.AddParameter("application/json", JsonSerialzer.SerializeObject(obj), ParameterType.RequestBody);

            return PerformCall(request, Method.POST);
        }

        /// <summary>
        /// Execute request and result result.
        /// </summary>
        /// <typeparam name="TReturn">Return type.</typeparam>
        /// <param name="uri">Request uri.</param>
        /// <param name="obj">Object to submit.</param>
        /// <returns>Object of type <typeparamref name="TReturn"/>.</returns>
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
                throw new NotImplementedException(nameof(JsonSerialzer));
            }

            return JsonSerialzer.DeserializeObject<TReturn>(Execute(uri, obj));
        }
    }
}
