using Laixer.Kadaster.Bag;
using System;

namespace Laixer.Kadaster
{
    /// <summary>
    /// Extensions on the kadaser bag registration.
    /// </summary>
    public static class KadasterBagExtensions
    {
        public static DesignationService DesignationService(this KadasterBag bag)
        {
            if (bag == null)
            {
                throw new ArgumentNullException(nameof(bag));
            }

            return bag.GetService(BagService.Designation) as DesignationService;
        }

        public static PremiseService PremiseService(this KadasterBag bag)
        {
            if (bag == null)
            {
                throw new ArgumentNullException(nameof(bag));
            }

            return bag.GetService(BagService.Premise) as PremiseService;
        }

        public static CityService CityService(this KadasterBag bag)
        {
            if (bag == null)
            {
                throw new ArgumentNullException(nameof(bag));
            }

            return bag.GetService(BagService.City) as CityService;
        }

        public static PublicSpaceService PublicSpaceService(this KadasterBag bag)
        {
            if (bag == null)
            {
                throw new ArgumentNullException(nameof(bag));
            }

            return bag.GetService(BagService.PublicSpace) as PublicSpaceService;
        }
    }
}
