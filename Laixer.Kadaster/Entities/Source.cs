using Newtonsoft.Json;

namespace Laixer.Kadaster.Entities
{
    /// <summary>
    /// Document source.
    /// </summary>
    public class Source
    {
        [JsonProperty("documentnummer")]
        public string DocumentId { get; set; }

        [JsonProperty("documentdatum")]
        public string DocumentDate { get; set; }
    }
}
