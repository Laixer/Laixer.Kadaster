﻿using Laixer.Kadaster.Entities;
using Laixer.Kadaster.Entities.Embed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Laixer.Kadaster.Bag
{
    /// <summary>
    /// Premise service.
    /// </summary>
    public class PremiseService : ServiceBase<Premise>
    {
        public PremiseService(IRemoteProcedure remoteProcedure)
            : base(remoteProcedure)
        {
        }

        private class PremiseList
        {
            [JsonProperty("panden")]
            public IList<Premise> Premises { get; set; } = new List<Premise>();
        }

        /// <summary>
        /// Return all instances of type <see cref="Premise"/>.
        /// </summary>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns>
        public override IEnumerable<BagObject<Premise>> GetAll(int limit = 0)
        {
            int page = 1;
            int itemCounter = 0;

            do
            {
                var r = new
                {
                    geometrie = new
                    {
                        within = new
                        {
                            type = "Polygon",
                            coordinates = new double[,,]
                            {{{4.3818283, 51.9497670},
                            {4.4125557, 51.9485503},
                            {4.4517803, 51.9715044},
                            {4.4211388, 51.9935484},
                            {4.3368530, 51.9736723},
                            {4.3562722, 51.9442517},
                            {4.3818283, 51.9497670}}}
                        }
                    }
                };

                var data = _remoteProcedure.Execute<EmbeddingEntity<PremiseList>>($"panden?page={page}", r);
                foreach (var item in data.Embed.Premises)
                {
                    // Return from enumerable when limit is set and reached.
                    if (limit > 0 && limit == itemCounter)
                    {
                        yield break;
                    }

                    ++itemCounter;
                    yield return ItemAsBagObject(item);
                }

                if (data.Embed.Premises.Count == 0)
                {
                    yield break;
                }

                // TODO: Only continue when more data is available

                page++;
            } while (true);
        }

        protected override BagObject<Premise> ItemAsBagObject(Premise item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (item.BuiltYear > 2100)
            {
                item.BuiltYear = null;
            }
            else if (item.BuiltYear == 0)
            {
                item.BuiltYear = null;
            }

            return base.ItemAsBagObject(item);
        }

        /// <summary>
        /// Return a singe entity of type <see cref="Premise"/>.
        /// </summary>
        /// <param name="id">Entity identifier.</param>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns
        public override BagObject<Premise> GetById(BagId id) => GetById(id, $"panden/{id}");
    }
}
