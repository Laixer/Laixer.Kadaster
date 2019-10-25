using Laixer.Kadaster.Bag;
using Laixer.Kadaster.Internal;
using System;

namespace Laixer.Kadaster
{
    /// <summary>
    /// BAG Kadaster registration.
    /// </summary>
    public class KadasterBag : IKadasterRegistration<BagService>
    {
        private const string baseUrl = "https://bag.basisregistraties.overheid.nl/api/v1/";
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
            : this(config, new BagRemoteProcedure(baseUrl, config.AuthKey)
            {
                JsonSerialzer = new JsonNetSerializer()
            })
        {
        }

        /// <summary>
        /// Create new instance.
        /// </summary>
        /// <param name="config">See <see cref="KadasterConfig"/>.</param>
        /// <param name="procedure">Instance of <see cref="IRemoteProcedure"/>.</param>
        public KadasterBag(KadasterConfig config, IRemoteProcedure procedure)
        {
            Config = config;
            procInterface = procedure;
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
                    return new DesignationService(procInterface);
                case BagService.Premise:
                    return new PremiseService(procInterface);
                case BagService.ResidentialObject:
                    break;
                case BagService.City:
                    return new CityService(procInterface);
                case BagService.PublicSpace:
                    return new PublicSpaceService(procInterface);
                default:
                    break;
            }

            throw new InvalidOperationException(nameof(designation));
        }
    }
}
