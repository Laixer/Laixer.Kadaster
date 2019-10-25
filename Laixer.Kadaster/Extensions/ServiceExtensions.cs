using Laixer.Kadaster.Bag;
using Laixer.Kadaster.Entities;

namespace Laixer.Kadaster
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Request public space from designation.
        /// </summary>
        /// <param name="bagObject"></param>
        /// <param name="bag"></param>
        /// <returns></returns>
        public static BagObject<PublicSpace> PublicSpace(this BagObject<Designation> bagObject, KadasterBag bag)
        {
            var publicSpaceService = bag.PublicSpaceService();
            var uri = bagObject.Value.Links.PublicSpace.Href;
            var id = uri.Segments[4];
            return publicSpaceService.GetById(new BagId(id));
        }
    }
}
