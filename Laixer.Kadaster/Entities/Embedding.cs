using Newtonsoft.Json;

namespace Laixer.Kadaster.Entities
{
    public class Embedding
    {
        [JsonProperty("geldigVoorkomen")]
        public Occurrence Occurrence { get; set; }
    }
}
