using Laixer.Kadaster.Entities.Embed;
using Newtonsoft.Json;

namespace Laixer.Kadaster.Entities
{
    /// <summary>
    /// City entity.
    /// </summary>
    public class City
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
        public EmbeddingGeometry Embed { get; set; }
    }
}
