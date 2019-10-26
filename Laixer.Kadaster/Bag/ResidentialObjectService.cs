using Laixer.Kadaster.Entities;
using Laixer.Kadaster.Entities.Embed;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Laixer.Kadaster.Bag
{
    public class ResidentialObjectService : ServiceBase<ResidentialObject>
    {
        public ResidentialObjectService(IRemoteProcedure remoteProcedure)
            : base(remoteProcedure)
        {
        }

        private class ResidentialObjectList
        {
            [JsonProperty("verblijfsobjecten")]
            public IList<ResidentialObject> ResidentialObjects { get; set; } = new List<ResidentialObject>();
        }

        /// <summary>
        /// Return all instances of type <see cref="ResidentialObject"/>.
        /// </summary>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns>
        public override IEnumerable<BagObject<ResidentialObject>> GetAll(int limit = 0)
        {
            int page = 1;
            int itemCount = 0;

            do
            {
                var data = _remoteProcedure.Query<EmbeddingEntity<ResidentialObjectList>>($"verblijfsobjecten?page={page}");
                foreach (var item in data.Embed.ResidentialObjects)
                {
                    if (limit > 0 && itemCount == limit)
                    {
                        yield break;
                    }

                    ++itemCount;
                    yield return ItemAsBagObject(item);
                }

                if (data.Embed.ResidentialObjects.Count == 0)
                {
                    yield break;
                }

                page++;
            } while (true);
        }

        /// <summary>
        /// Return a singe entity of type <see cref="ResidentialObject"/>.
        /// </summary>
        /// <param name="id">Entity identifier.</param>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns
        public override BagObject<ResidentialObject> GetById(BagId id) => GetById(id, $"verblijfsobjecten/{id}");
    }
}
