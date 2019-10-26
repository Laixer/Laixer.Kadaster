using Laixer.Kadaster.Entities;
using Laixer.Kadaster.Entities.Embed;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Laixer.Kadaster.Bag
{
    /// <summary>
    /// Designation service.
    /// </summary>
    public class DesignationService : ServiceBase<Designation>
    {
        public DesignationService(IRemoteProcedure remoteProcedure)
            : base(remoteProcedure)
        {
        }

        private class DesignationList
        {
            [JsonProperty("nummeraanduidingen")]
            public IList<Designation> Designations { get; set; } = new List<Designation>();
        }

        /// <summary>
        /// Return all instances of type <see cref="Designation"/>.
        /// </summary>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns>
        public override IEnumerable<BagObject<Designation>> GetAll(int limit = 0)
        {
            int page = 1;
            int itemCount = 0;

            do
            {
                var data = _remoteProcedure.Query<EmbeddingEntity<DesignationList>>($"nummeraanduidingen?page={page}");
                foreach (var item in data.Embed.Designations)
                {
                    if (limit > 0 && itemCount == limit)
                    {
                        yield break;
                    }

                    ++itemCount;
                    yield return ItemAsBagObject(item);
                }

                if (data.Embed.Designations.Count == 0)
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
                var data = _remoteProcedure.Query<EmbeddingEntity<DesignationList>>(houseNumber != null
                    ? $"nummeraanduidingen?postcode={postcode}&huisnummer={houseNumber}&page={page}"
                    : $"nummeraanduidingen?postcode={postcode}&page={page}");

                foreach (var item in data.Embed.Designations)
                {
                    if (limit > 0 && itemCount == limit)
                    {
                        yield break;
                    }

                    ++itemCount;
                    yield return ItemAsBagObject(item);
                }

                if (data.Embed.Designations.Count == 0)
                {
                    yield break;
                }

                page++;
            } while (true);
        }

        /// <summary>
        /// Return a singe entity of type <see cref="Designation"/>.
        /// </summary>
        /// <param name="id">Entity identifier.</param>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns
        public override BagObject<Designation> GetById(BagId id) => GetById(id, $"nummeraanduidingen/{id}");
    }
}
