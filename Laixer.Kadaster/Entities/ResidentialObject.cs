using Laixer.Kadaster.Entities.Embed;
using Newtonsoft.Json;

namespace Laixer.Kadaster.Entities
{
    public class ResidentialObjectResourceConnection
    {
        [JsonProperty("self")]
        public ResourceConnection Self { get; set; }

        [JsonProperty("voorkomens")]
        public ResourceConnection Occurrence { get; set; }

        [JsonProperty("hoofdadres")]
        public ResourceConnection Designation { get; set; }
    }

    /// <summary>
    /// Residential object entity.
    /// </summary>
    public class ResidentialObject
    {
        [JsonProperty("identificatiecode")]
        public string Id { get; set; }

        [JsonProperty("oppervlakte")]
        public int Surface { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddingGeometryPoint Embed { get; set; }

        [JsonProperty("_links")]
        public ResidentialObjectResourceConnection Links { get; set; }
    }
}
