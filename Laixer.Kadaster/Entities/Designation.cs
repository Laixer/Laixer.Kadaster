using Newtonsoft.Json;

namespace Laixer.Kadaster.Entities
{
    public class DesignationResourceConnection
    {
        [JsonProperty("self")]
        public ResourceConnection Self { get; set; }

        [JsonProperty("bijbehorendeOpenbareRuimte")]
        public ResourceConnection PublicSpace { get; set; }

        [JsonProperty("voorkomens")]
        public ResourceConnection Occurrence { get; set; }

        [JsonProperty("adresseerbaarObject")]
        public ResourceConnection AddressObject { get; set; }
    }

    /// <summary>
    /// Designation entity.
    /// </summary>
    public class Designation
    {
        [JsonProperty("identificatiecode")]
        public string Id { get; set; }

        [JsonProperty("huisletter")]
        public string HouseLetter { get; set; }

        [JsonProperty("huisnummer")]
        public int HouseNumber { get; set; }

        [JsonProperty("huisnummertoevoeging")]
        public string HouseNumberAddition { get; set; }

        [JsonProperty("postcode")]
        public string Postcode { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("_embedded")]
        public Embedding Embed { get; set; }

        [JsonProperty("_links")]
        public DesignationResourceConnection Links { get; set; }

        /// <summary>
        /// Represent as string.
        /// </summary>
        /// <returns>String representation.</returns>
        public override string ToString()
        {
            if (string.IsNullOrEmpty(HouseLetter))
            {
                return $"{Postcode} {HouseNumber}{HouseLetter}";
            }

            if (!string.IsNullOrEmpty(HouseNumberAddition))
            {
                return $"{Postcode} {HouseNumber} {HouseNumberAddition}";
            }

            return $"{Postcode} {HouseNumber}";
        }
    }
}
