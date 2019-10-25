using Laixer.Kadaster.Entities;
using RestSharp;
using System.Collections.Generic;

namespace Laixer.Kadaster.Bag
{
    public class PublicSpaceService : IBagService<PublicSpace>
    {
        private readonly IRemoteProcedure remoteProcedure;

        public PublicSpaceService(IRestClient client, IRemoteProcedure remoteProcedure)
        {
            this.remoteProcedure = remoteProcedure;
        }

        private class PublicSpaceList
        {
            public IList<PublicSpace> openbareRuimtes { get; set; } = new List<PublicSpace>();
        }

        public IEnumerable<BagObject<PublicSpace>> GetAll(int limit = 0)
        {
            int page = 1;
            int itemCount = 0;

            do
            {
                var data = remoteProcedure.Query<ApplicationLanguage<PublicSpaceList>>($"openbare-ruimtes?page={page}");
                foreach (var item in data._embedded.openbareRuimtes)
                {
                    if (limit > 0 && itemCount == limit)
                    {
                        yield break;
                    }

                    ++itemCount;
                    yield return ItemAsBagObject(item);
                }

                if (data._embedded.openbareRuimtes.Count == 0)
                {
                    yield break;
                }

                page++;
            } while (true);
        }

        private BagObject<PublicSpace> ItemAsBagObject(PublicSpace item)
        {
            return new BagObject<PublicSpace>
            {
                Value = item
            };
        }

        public BagObject<PublicSpace> GetById(BagId id)
        {
            return ItemAsBagObject(remoteProcedure.Query<PublicSpace>($"openbare-ruimtes/{id}"));
        }
    }
}
