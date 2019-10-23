using Laixer.Kadaster.Bag;
using Laixer.Kadaster.Internal;
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
        private readonly IRestClient client = new RestClient(baseUrl);
        private readonly IRemoteProcedure procInterface;

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

            procInterface = new BagRemoteProcedure(baseUrl, Config.ApiKey)
            {
                JsonSerialzer = new JsonNetSerializer()
            };

            // TODO: RemoteClient provider?
            client.AddDefaultHeader("X-Api-Key", Config.ApiKey);
            client.AddDefaultHeader("Accept", "application/hal+json");
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
                    return new DesignationService(client);
                case BagService.Premise:
                    return new PremiseService(client, procInterface);
                case BagService.ResidentialObject:
                    break;
                case BagService.City:
                    return new CityService(client);
                case BagService.PublicSpace:
                    return new PublicSpaceService(client);
                default:
                    break;
            }

            throw new InvalidOperationException(nameof(designation));
        }
    }
}
