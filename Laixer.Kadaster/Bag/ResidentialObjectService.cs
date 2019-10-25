using Laixer.Kadaster.Entities;
using Newtonsoft.Json;
using System;
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
            public IList<Premise> ResidentialObjects { get; set; } = new List<Premise>();
        }

        /// <summary>
        /// Return all instances of type <see cref="ResidentialObject"/>.
        /// </summary>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns>
        public override IEnumerable<BagObject<ResidentialObject>> GetAll(int limit = 0)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return a singe entity of type <see cref="ResidentialObject"/>.
        /// </summary>
        /// <param name="id">Entity identifier.</param>
        /// <returns>Instance of <see cref="BagObject{T}"/>.</returns
        public override BagObject<ResidentialObject> GetById(BagId id)
        {
            throw new NotImplementedException();
        }
    }
}
