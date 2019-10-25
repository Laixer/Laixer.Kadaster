using Laixer.Kadaster.Entities;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace Laixer.Kadaster.Bag
{
    public class DesignationService : IBagService<Designation>
    {
        private readonly IRemoteProcedure remoteProcedure;

        public DesignationService(IRestClient client, IRemoteProcedure remoteProcedure)
        {
            this.remoteProcedure = remoteProcedure;
        }

        private class DesignationList
        {
            [JsonProperty("nummeraanduidingen")]
            public IList<Designation> Designations { get; set; } = new List<Designation>();
        }

        public IEnumerable<BagObject<Designation>> GetAll(int limit = 0)
        {
            int page = 1;
            int itemCount = 0;

            do
            {
                var data = remoteProcedure.Query<ApplicationLanguage<DesignationList>>($"nummeraanduidingen?page={page}");
                foreach (var item in data._embedded.Designations)
                {
                    if (limit > 0 && itemCount == limit)
                    {
                        yield break;
                    }

                    ++itemCount;
                    yield return ItemAsBagObject(item);
                }

                if (data._embedded.Designations.Count == 0)
                {
                    yield break;
                }

                page++;
            } while (true);
        }

        public IEnumerable<BagObject<Designation>> GetAll(string postcode, int? houseNumber = null, int limit = 0)
        {
            int page = 1;
            int itemCount = 0;

            do
            {
                var data = remoteProcedure.Query<ApplicationLanguage<DesignationList>>(houseNumber != null
                    ? $"nummeraanduidingen?postcode={postcode}&huisnummer={houseNumber}&page={page}"
                    : $"nummeraanduidingen?postcode={postcode}&page={page}");

                foreach (var item in data._embedded.Designations)
                {
                    if (limit > 0 && itemCount == limit)
                    {
                        yield break;
                    }

                    ++itemCount;
                    yield return ItemAsBagObject(item);
                }

                if (data._embedded.Designations.Count == 0)
                {
                    yield break;
                }

                page++;
            } while (true);
        }

        private BagObject<Designation> ItemAsBagObject(Designation item)
        {
            return new BagObject<Designation>
            {
                Value = item
            };
        }

        public BagObject<Designation> GetById(BagId id)
        {
            return ItemAsBagObject(remoteProcedure.Query<Designation>($"nummeraanduidingen/{id}"));
        }
    }
}
