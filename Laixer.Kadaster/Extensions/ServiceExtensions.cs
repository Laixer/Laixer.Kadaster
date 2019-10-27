using Laixer.Kadaster.Bag;
using Laixer.Kadaster.Entities;
using System;

namespace Laixer.Kadaster
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Request public space from designation.
        /// </summary>
        /// <param name="bagObject">Entity to extend.</param>
        /// <param name="bag">BAG registrar.</param>
        /// <returns><see cref="BagObject{PublicSpace}"/>.</returns>
        public static BagObject<PublicSpace> PublicSpace(this BagObject<Designation> bagObject, KadasterBag bag)
        {
            if (bagObject == null)
            {
                throw new ArgumentNullException(nameof(bagObject));
            }

            if (bag == null)
            {
                throw new ArgumentNullException(nameof(bag));
            }

            var publicSpaceService = bag.PublicSpaceService();
            var uri = bagObject.Value.Links.PublicSpace.Href;
            var id = uri.Segments[4]; // TODO: This may not always be true;
            return publicSpaceService.GetById(new BagId(id));
        }

        /// <summary>
        /// Request residential object from designation.
        /// </summary>
        /// <param name="bagObject">Entity to extend.</param>
        /// <param name="bag">BAG registrar.</param>
        /// <returns><see cref="BagObject{ResidentialObject}"/>.</returns>
        public static BagObject<ResidentialObject> ResidentialObject(this BagObject<Designation> bagObject, KadasterBag bag)
        {
            if (bagObject == null)
            {
                throw new ArgumentNullException(nameof(bagObject));
            }

            if (bag == null)
            {
                throw new ArgumentNullException(nameof(bag));
            }

            var residentialObjectService = bag.ResidentialObjectService();
            var uri = bagObject.Value.Links.AddressObject.Href;
            switch (uri.Segments[3].Replace("/", null).Trim().ToLower())
            {
                case "verblijfsobjecten":
                    var id = uri.Segments[4]; // TODO: This may not always be true;
                    return residentialObjectService.GetById(new BagId(id));
                default:
                    break;
            }

            return null;
        }

        /// <summary>
        /// Request city from designation.
        /// </summary>
        /// <param name="bagObject">Entity to extend.</param>
        /// <param name="bag">BAG registrar.</param>
        /// <returns><see cref="BagObject{City}"/>.</returns>
        public static BagObject<City> City(this BagObject<PublicSpace> bagObject, KadasterBag bag)
        {
            if (bagObject == null)
            {
                throw new ArgumentNullException(nameof(bagObject));
            }

            if (bag == null)
            {
                throw new ArgumentNullException(nameof(bag));
            }

            var cityService = bag.CityService();
            var uri = bagObject.Value.Links.City.Href;
            var id = uri.Segments[4]; // TODO: This may not always be true;
            return cityService.GetById(new BagId(id));
        }

        /// <summary>
        /// Request residential object from premise.
        /// </summary>
        /// <param name="bagObject">Entity to extend.</param>
        /// <param name="bag">BAG registrar.</param>
        /// <returns><see cref="BagObject{ResidentialObject}"/>.</returns>
        public static BagObject<ResidentialObject> ResidentialObject(this BagObject<Premise> bagObject, KadasterBag bag)
        {
            if (bagObject == null)
            {
                throw new ArgumentNullException(nameof(bagObject));
            }

            if (bag == null)
            {
                throw new ArgumentNullException(nameof(bag));
            }

            var residentialObjectService = bag.ResidentialObjectService();
            var uri = bagObject.Value.Links.ResidentialObject.Href;
            var id = uri.Segments[4]; // TODO: This may not always be true;
            return residentialObjectService.GetById(new BagId(id));
        }
    }
}
