using Laixer.Kadaster.Entities;
using Laixer.Kadaster.Entities.Embed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Laixer.Kadaster.UnitTests
{
    /// <summary>
    /// Remote procedure service mocking API service.
    /// </summary>
    internal sealed class MockEndpointProcedure : IRemoteProcedure
    {
        public const string BaseUrl = "https://localhost/";

        public IJsonSerialzer JsonSerialzer { get; set; }

        private class PremiseList
        {
            [JsonProperty("panden")]
            public IList<Premise> Premises { get; set; } = new List<Premise>();
        }

        private static class PremiseController
        {
            public static IReadOnlyList<Premise> GetAll()
            {
                return EntityRepository.Premises;
            }

            public static Premise GetBydId(string id)
            {
                foreach (var item in EntityRepository.Premises)
                {
                    if (item.Id == id)
                    {
                        return item;
                    }
                }

                return null;
            }
        }

        private string HandleUri(string uri, object obj = null)
        {
            var fakeEndpoint = new Uri(BaseUrl + uri);
            switch (fakeEndpoint.Segments[1].Replace("/", null, StringComparison.OrdinalIgnoreCase).Trim().ToUpperInvariant())
            {
                case "PANDEN":
                    {
                        if (fakeEndpoint.Segments.Length > 2)
                        {
                            var bagId = fakeEndpoint.Segments[2].Replace("/", null, StringComparison.OrdinalIgnoreCase).Trim();
                            return JsonConvert.SerializeObject(PremiseController.GetBydId(bagId));
                        }

                        var embed = new EmbeddingEntity<PremiseList>
                        {
                            Embed = new PremiseList
                            {
                                Premises = (IList<Premise>)PremiseController.GetAll(),
                            }
                        };

                        return JsonConvert.SerializeObject(embed);
                    }

                case "VERBLIJFSOBJECTEN":
                    break;

                case "OPENBARE-RUIMTES":
                    break;

                case "NUMMERAANDUIDINGEN":
                    break;

                case "WOONPLAATSEN":
                    break;

                default:
                    break;
            }

            return null;
        }

        /// <summary>
        /// Perform query with result based on uri.
        /// </summary>
        /// <param name="uri">Request uri.</param>
        /// <returns>Result as string, if any.</returns>
        public string Execute(string uri, object obj) => HandleUri(uri, obj);

        /// <summary>
        /// Perform query with result based on uri.
        /// </summary>
        /// <typeparam name="TReturn">Return type.</typeparam>
        /// <param name="uri">Request uri.</param>
        /// <returns>Object of type <typeparamref name="TReturn"/>.</returns>
        public TReturn Execute<TReturn>(string uri, object obj) => JsonConvert.DeserializeObject<TReturn>(HandleUri(uri, obj));

        /// <summary>
        /// Execute request and result result.
        /// </summary>
        /// <param name="uri">Request uri.</param>
        /// <param name="obj">Object to submit.</param>
        /// <returns>Result as string, if any.</returns>
        public string Query(string uri) => HandleUri(uri);

        /// <summary>
        /// Execute request and result result.
        /// </summary>
        /// <typeparam name="TReturn">Return type.</typeparam>
        /// <param name="uri">Request uri.</param>
        /// <param name="obj">Object to submit.</param>
        /// <returns>Object of type <typeparamref name="TReturn"/>.</returns>
        public TReturn Query<TReturn>(string uri) => JsonConvert.DeserializeObject<TReturn>(HandleUri(uri));
    }
}
