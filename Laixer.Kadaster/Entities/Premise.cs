using Laixer.Kadaster.Entities.Embed;
using Newtonsoft.Json;

namespace Laixer.Kadaster.Entities
{
    public class PremiseResourceConnection
    {
        [JsonProperty("self")]
        public ResourceConnection Self { get; set; }

        [JsonProperty("voorkomens")]
        public ResourceConnection Occurrence { get; set; }

        [JsonProperty("verblijfsobjecten")]
        public ResourceConnection ResidentialObject { get; set; }
    }

    /// <summary>
    /// Premise entity.
    /// </summary>
    public class Premise
    {
        [JsonProperty("identificatiecode")]
        public string Id { get; set; }

        [JsonProperty("oorspronkelijkBouwjaar")]
        public int? BuiltYear { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddingGeometry Embed { get; set; }

        [JsonProperty("_links")]
        public PremiseResourceConnection Links { get; set; }
    }
}
