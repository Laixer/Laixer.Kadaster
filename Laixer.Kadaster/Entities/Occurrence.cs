using Newtonsoft.Json;

namespace Laixer.Kadaster.Entities
{
    public class Occurrence
    {
        [JsonProperty("beginGeldigheid")]
        public string ValidFrom { get; set; }

        [JsonProperty("eindGeldigheid")]
        public string ValidTil { get; set; }

        [JsonProperty("inOnderzoek")]
        public bool UnderInvestigation { get; set; }

        [JsonProperty("aanduidingInactief")]
        public bool AppointmentActive { get; set; }

        [JsonProperty("aanduidingCorrectie")]
        public int AppointmentCorrection { get; set; }

        [JsonProperty("geconstateerd")]
        public bool Established { get; set; }
    }
}
