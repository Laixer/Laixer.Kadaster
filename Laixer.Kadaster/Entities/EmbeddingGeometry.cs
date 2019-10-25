using Newtonsoft.Json;

namespace Laixer.Kadaster.Entities
{
    public class EmbeddingGeometry : Embedding
    {
        [JsonProperty("geometrie")]
        public dynamic Geometry { get; set; }
    }
}
