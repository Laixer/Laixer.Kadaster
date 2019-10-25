using Newtonsoft.Json;
using System;

namespace Laixer.Kadaster.Entities
{
    /// <summary>
    /// Connection to other resources.
    /// </summary>
    public class ResourceConnection
    {
        /// <summary>
        /// Uri to other resources.
        /// </summary>
        [JsonProperty("href")]
        public Uri Href { get; set; }
    }
}
