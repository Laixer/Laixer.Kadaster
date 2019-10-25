using Newtonsoft.Json;

namespace Laixer.Kadaster.Entities
{
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
