using Newtonsoft.Json;

namespace Laixer.Kadaster.Entities.Embed
{
    public class EmbeddingGeometryPoint : Embedding
    {
        [JsonProperty("geometrie")]
        public GeometryPoint Geometry { get; set; }
    }
}
