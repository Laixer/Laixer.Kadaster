using Newtonsoft.Json;
using System.Collections.Generic;

namespace Laixer.Kadaster.Entities
{
    public class Geometry
    {
        public class GeometryCrs
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("properties")]
            public dynamic Properties { get; set; }
        }

        [JsonProperty("coordinates")]
        public List<List<List<double>>> Coordination { get; set; } = new List<List<List<double>>>();

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("crs")]
        public GeometryCrs Crs { get; set; }
    }
}
