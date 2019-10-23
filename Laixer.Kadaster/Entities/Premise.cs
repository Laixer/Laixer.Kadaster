namespace Laixer.Kadaster.Entities
{
    public class Premise
    {
        public string identificatiecode { get; set; }
        public int? oorspronkelijkBouwjaar { get; set; }
        public string status { get; set; }
        public string GeoJson { get; set; }
    }
}
