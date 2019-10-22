using RestSharp;
using System;

namespace Laixer.Kadaster
{
    /// <summary>
    /// BAG Kadaster registration.
    /// </summary>
    public class KadasterBag : IKadasterRegistration<BagService>
    {
        private const string baseUrl = "https://bag.basisregistraties.overheid.nl/api/v1/";
        private readonly IRestClient _client;

        /// <summary>
        /// Registration service configuration.
        /// </summary>
        public KadasterConfig Config { get; }

        /// <summary>
        /// Create new instance.
        /// </summary>
        /// <param name="config">See <see cref="KadasterConfig"/>.</param>
        public KadasterBag(KadasterConfig config)
        {
            Config = config;

            // TODO: RemoteClient provider?
            _client = new RestClient(baseUrl);
            _client.AddDefaultHeader("X-Api-Key", Config.ApiKey);
            _client.AddDefaultHeader("Accept", "application/hal+json");
        }

        /// <summary>
        /// Return a service available in this registration.
        /// </summary>
        /// <param name="designation"></param>
        /// <returns>Instance of <see cref="IBagService"/>.</returns>
        public IBagService GetService(BagService designation)
        {
            switch (designation)
            {
                case BagService.Designation:
                    return new DesignationService(_client);
                case BagService.Premise:
                    break;
                case BagService.ResidentialObject:
                    break;
                case BagService.City:
                    return new CityService(_client);
                default:
                    break;
            }

            throw new InvalidOperationException(); // TODO:
        }
    }
}
