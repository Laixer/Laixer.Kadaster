using Newtonsoft.Json;

namespace Laixer.Kadaster
{
    public class ApplicationLanguage<TEntity>
        where TEntity : class
    {
        [JsonProperty("_links")]
        public dynamic Links { get; set; }

        [JsonProperty("_embedded")]
        public TEntity Embed { get; set; }
    }
}
