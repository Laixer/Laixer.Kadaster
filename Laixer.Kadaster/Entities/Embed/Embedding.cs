using Newtonsoft.Json;

namespace Laixer.Kadaster.Entities.Embed
{
    public class Embedding
    {
        [JsonProperty("geldigVoorkomen")]
        public Occurrence Occurrence { get; set; }
    }
}
