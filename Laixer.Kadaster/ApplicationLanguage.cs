namespace Laixer.Kadaster
{
    public class ApplicationLanguage<TEntity>
        where TEntity : class
    {
        public dynamic _links { get; set; }
        public TEntity _embedded { get; set; }
    }
}
