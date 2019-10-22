namespace Laixer.Kadaster.Entities
{
    public class Occurrence
    {
        public string beginGeldigheid { get; set; }
        public string eindGeldigheid { get; set; }
        public bool inOnderzoek { get; set; }
        public bool aanduidingInactief { get; set; }
        public int aanduidingCorrectie { get; set; }
        public bool geconstateerd { get; set; }
    }
}
