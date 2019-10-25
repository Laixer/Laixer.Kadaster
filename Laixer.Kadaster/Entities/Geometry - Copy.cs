using Newtonsoft.Json;
using System.Collections.Generic;

namespace Laixer.Kadaster.Entities
{
    public class GeometryPoint
    {
        public class GeometryCrs
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("properties")]
            public dynamic Properties { get; set; }
        }

        [JsonProperty("coordinates")]
        public List<double> Coordination { get; set; } = new List<double>();

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("crs")]
        public GeometryCrs Crs { get; set; }
    }
}
