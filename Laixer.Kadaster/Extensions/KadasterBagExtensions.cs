using Laixer.Kadaster.Bag;
using System;

namespace Laixer.Kadaster
{
    /// <summary>
    /// Extensions on the kadaser bag registration.
    /// </summary>
    public static class KadasterBagExtensions
    {
        /// <summary>
        /// Get bag designation service.
        /// </summary>
        /// <param name="bag">Factory to extend.</param>
        /// <returns>See <see cref="Bag.DesignationService"/>.</returns>
        public static DesignationService DesignationService(this KadasterBag bag)
        {
            if (bag == null)
            {
                throw new ArgumentNullException(nameof(bag));
            }

            return bag.GetService(BagService.Designation) as DesignationService;
        }

        /// <summary>
        /// Get bag premise service.
        /// </summary>
        /// <param name="bag">Factory to extend.</param>
        /// <returns>See <see cref="Bag.PremiseService"/>.</returns>
        public static PremiseService PremiseService(this KadasterBag bag)
        {
            if (bag == null)
            {
                throw new ArgumentNullException(nameof(bag));
            }

            return bag.GetService(BagService.Premise) as PremiseService;
        }

        /// <summary>
        /// Get bag city service.
        /// </summary>
        /// <param name="bag">Factory to extend.</param>
        /// <returns>See <see cref="Bag.CityService"/>.</returns>
        public static CityService CityService(this KadasterBag bag)
        {
            if (bag == null)
            {
                throw new ArgumentNullException(nameof(bag));
            }

            return bag.GetService(BagService.City) as CityService;
        }

        /// <summary>
        /// Get bag public space service.
        /// </summary>
        /// <param name="bag">Factory to extend.</param>
        /// <returns>See <see cref="Bag.PublicSpaceService"/>.</returns>
        public static PublicSpaceService PublicSpaceService(this KadasterBag bag)
        {
            if (bag == null)
            {
                throw new ArgumentNullException(nameof(bag));
            }

            return bag.GetService(BagService.PublicSpace) as PublicSpaceService;
        }

        /// <summary>
        /// Get bag residential object service.
        /// </summary>
        /// <param name="bag">Factory to extend.</param>
        /// <returns>See <see cref="Bag.ResidentialObjectService"/>.</returns>
        public static ResidentialObjectService ResidentialObjectService(this KadasterBag bag)
        {
            if (bag == null)
            {
                throw new ArgumentNullException(nameof(bag));
            }

            return bag.GetService(BagService.ResidentialObject) as ResidentialObjectService;
        }
    }
}
