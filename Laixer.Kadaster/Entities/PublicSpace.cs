using Laixer.Kadaster.Entities.Embed;
using Newtonsoft.Json;

namespace Laixer.Kadaster.Entities
{
    public class PublicSpaceResourceConnection
    {
        [JsonProperty("self")]
        public ResourceConnection Self { get; set; }

        [JsonProperty("voorkomens")]
        public ResourceConnection Occurrence { get; set; }

        [JsonProperty("bijbehorendeWoonplaats")]
        public ResourceConnection City { get; set; }
    }

    /// <summary>
    /// Public space entity.
    /// </summary>
    public class PublicSpace
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [JsonProperty("identificatiecode")]
        public string Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [JsonProperty("naam")]
        public string Name { get; set; }

        /// <summary>
        /// Status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("_embedded")]
        public Embedding Embed { get; set; }

        [JsonProperty("_links")]
        public PublicSpaceResourceConnection Links { get; set; }
    }
}
