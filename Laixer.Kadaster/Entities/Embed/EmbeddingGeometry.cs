using Newtonsoft.Json;

namespace Laixer.Kadaster.Entities.Embed
{
    public class EmbeddingGeometry : Embedding
    {
        [JsonProperty("geometrie")]
        public Geometry Geometry { get; set; }
    }
}
