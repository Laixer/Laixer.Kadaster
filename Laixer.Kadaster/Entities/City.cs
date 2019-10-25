using Newtonsoft.Json;

namespace Laixer.Kadaster.Entities
{
    /// <summary>
    /// City entity.
    /// </summary>
    public class City
    {
        [JsonProperty("identificatiecode")]
        public string Id { get; set; }

        [JsonProperty("naam")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("_embedded")]
        public EmbeddingGeometry Embed { get; set; }

        public string GeoJson { get; set; }
    }
}
