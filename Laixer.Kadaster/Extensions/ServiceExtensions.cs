﻿using Laixer.Kadaster.Bag;
using Laixer.Kadaster.Entities;

namespace Laixer.Kadaster
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Request public space from designation.
        /// </summary>
        /// <param name="bagObject">Entity to extend.</param>
        /// <param name="bag">BAG registrar.</param>
        /// <returns><see cref="BagObject<PublicSpace>"/>.</returns>
        public static BagObject<PublicSpace> PublicSpace(this BagObject<Designation> bagObject, KadasterBag bag)
        {
            var publicSpaceService = bag.PublicSpaceService();
            var uri = bagObject.Value.Links.PublicSpace.Href;
            var id = uri.Segments[4]; // TODO: This may not always be true;
            return publicSpaceService.GetById(new BagId(id));
        }

        /// <summary>
        /// Request city from designation.
        /// </summary>
        /// <param name="bagObject">Entity to extend.</param>
        /// <param name="bag">BAG registrar.</param>
        /// <returns><see cref="BagObject<City>"/>.</returns>
        public static BagObject<City> City(this BagObject<PublicSpace> bagObject, KadasterBag bag)
        {
            var cityService = bag.CityService();
            var uri = bagObject.Value.Links.City.Href;
            var id = uri.Segments[4]; // TODO: This may not always be true;
            return cityService.GetById(new BagId(id));
        }
    }
}
