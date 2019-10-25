using Newtonsoft.Json;

namespace Laixer.Kadaster.Entities.Embed
{
    public class EmbeddingSource
    {
        [JsonProperty("bron")]
        public Source Source { get; set; }
    }
}
